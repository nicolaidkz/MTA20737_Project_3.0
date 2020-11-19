using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMesh : MonoBehaviour
{
    NavMeshAgent agent;

    public List<GameObject> checkpoints;

    //remember to include using UnityEngine.AI;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(checkpoints[0].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "AI_CheckpointOne")
        {
            agent.SetDestination(checkpoints[1].transform.position);
        }
        else if (other.name == "AI_CheckpointTwo")
        {
            agent.SetDestination(checkpoints[2].transform.position);
        }
        else if (other.name == "AI_CheckpointThree")
        {
            agent.SetDestination(checkpoints[3].transform.position);
        }
        else if (other.name == "AI_StartPoint")
        {
            agent.SetDestination(checkpoints[0].transform.position);
        }
    }
}
