using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAgent : MonoBehaviour
{
    public Transform boat;
    public Transform start;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI_Boat")
        {
            boat.position = start.position;
            boat.rotation = start.rotation;
        }
    }
}
