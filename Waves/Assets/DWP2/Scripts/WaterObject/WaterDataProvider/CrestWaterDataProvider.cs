﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Crest;
using Random = UnityEngine.Random;

namespace DWP2
{
    public class CrestWaterDataProvider : WaterDataProvider
    {
        private OceanRenderer _oceanRenderer;
        private ICollProvider _collProvider;
        private IFlowProvider _flowProvider;
        private int _prevArraySize;
        Vector3[] _crestQueryHashArray;
        
        private Vector3[] _normals;
        private int _hash = -1;

        public override bool SupportsWaterHeightQueries()
        {
            return true;
        }

        public override bool SupportsWaterNormalQueries()
        {
            return true;
        }

        public override bool SupportsWaterFlowQueries()
        {
            return true;
        }
        
        public override void Awake()
        {
            base.Awake();
            
            _oceanRenderer = GetComponent<OceanRenderer>();
            if (_oceanRenderer == null)
            {
                Debug.LogError($"{typeof(OceanRenderer)} not found. " +
                               $"{GetType()} needs to be attached to an object containing {typeof(OceanRenderer)}.");
            }

            _prevArraySize = -1;
        }

        public override void GetWaterHeights(ref Vector3[] points, ref float[] waterHeights)
        {
            int n = points.Length;

            _collProvider = _oceanRenderer.CollisionProvider;
            _flowProvider = _oceanRenderer.FlowProvider;
            
            // Resize hash array if data size changed
            if (n != _prevArraySize)
            {
                _normals = new Vector3[n];
                _crestQueryHashArray = new Vector3[n];
                _hash = _crestQueryHashArray.GetHashCode();
                _prevArraySize = n;
            }

            _collProvider.Query(
                _hash, 0, points,
                waterHeights, _normals, null);

            _prevArraySize = n;
        }

        public override void GetWaterNormals(ref Vector3[] points, ref Vector3[] waterNormals)
        {
            waterNormals = _normals; // Already queried in GetWaterHeights
        }

        public override void GetWaterFlows(ref Vector3[] points, ref Vector3[] waterFlows)
        {
            _flowProvider.Query(_hash, 0, points, waterFlows);
        }

        public override float GetWaterHeightSingle(Vector3 point)
        {
            _singlePointArray[0] = point;
            _oceanRenderer.CollisionProvider.Query(_oceanRenderer.GetHashCode(), 0, 
                _singlePointArray, _singleHeightArray,null, null);
            return _singleHeightArray[0];
        }
    }
}
