using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomWindArea : MonoBehaviour
{

    List<Rigidbody> RigidbodiesInWindZoneList = new List<Rigidbody>();
    public Vector3 windDirection = Vector3.right;
    public float windStrengthMin = 500;
    public float windStrengthMax = 1500;
    //private bool applyForce = false;
    //private bool coroutineShouldStart = false;

    private void OnTriggerEnter(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
        if (objectRigid != null)
        {
            //applyForce = true;
            //coroutineShouldStart = true;
            RigidbodiesInWindZoneList.Add(objectRigid);
            Debug.Log(objectRigid.name);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
        if (objectRigid != null)
            RigidbodiesInWindZoneList.Remove(objectRigid);
    }

    //IEnumerator Wait()
    //{
    //    applyForce = true;
    //    Debug.Log("Waiting...");
    //    yield return new WaitForSecondsRealtime(Random.Range(0, 2));
    //    Debug.Log("Done Waiting!");

    //    float secondsToApplyForce = Random.Range(5, 10);

    //    foreach (Rigidbody rigid in RigidbodiesInWindZoneList)
    //    {
    //        if (applyForce)
    //        {
    //            for(int i = 0; i <= secondsToApplyForce; i++)
    //            {
    //                float randomStrength = Random.Range(windStrengthMin, windStrengthMax);
    //                rigid.AddForce(windDirection * randomStrength);
    //                Debug.Log("Force applied = " + randomStrength);
    //            }
    //            Debug.Log("Applied force over " + secondsToApplyForce + " seconds");
    //            applyForce = false;
    //            coroutineShouldStart = true;
    //        }
            
    //    }
    //}

    private void FixedUpdate()
    {
        if (RigidbodiesInWindZoneList.Count > 0)
        {
            foreach (Rigidbody rigid in RigidbodiesInWindZoneList)
            {
                float randomStrength = Random.Range(windStrengthMin, windStrengthMax);
                rigid.AddForce(windDirection * randomStrength);
                Debug.Log("Force applied = " + randomStrength);
            }
            //if (coroutineShouldStart)
            //{
            //    StartCoroutine(Wait());
            //    coroutineShouldStart = false;
            //}
        }
    }
}