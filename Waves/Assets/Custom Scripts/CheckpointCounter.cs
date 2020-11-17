using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointCounter : MonoBehaviour
{
    public int checkpointsTotal = 0;
    public static int checkpointsCounter = 0;
    public Text checkpointText;
    private static int correctCheckpointCounter = 1;
    private int isColliding = 0;
    private static bool error = false;
    private static bool isCollidingFlag = false;
    private static bool errorFlag = true;
    public GameObject destroyWaypoint;
    public Transform self;

    public List<Transform> checkpoints;
    public List<Transform> resets;

    // Start is called before the first frame update
    void Start()
    {
        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + " / " + checkpointsTotal;
        Waypoint.target = checkpoints[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        //true (no error)
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip")
        {
            isColliding++;
            Debug.Log(isColliding + " Counted in correct 1");
            if(isColliding == 1){
                updateCounter();
                Waypoint.target = checkpoints[1];
            }
            
        }
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 2 && other.name == "CheckpointTwoCollider" && this.tag == "PlayerShip")
        {
            isColliding++;
            Debug.Log(isColliding + " Counted in correct 2");
            if (isColliding == 1)
            {
                updateCounter();
                Waypoint.target = checkpoints[2];
            }

        }
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 3 && other.name == "CheckpointThreeCollider" && this.tag == "PlayerShip")
        {
            isColliding++;
            Debug.Log(isColliding + " Counted in correct 3");
            if (isColliding == 1)
            {
                updateCounter();
            }

        }

        //false(error)
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter > 1 && !(isColliding > 0) && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip" && errorFlag)
        {
            isColliding++;
            errorFlag = false;
            Debug.Log(isColliding + " Counted in error 1");
            if (isColliding == 1)
            {
                throwError();
            }
        }
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter != 2 && !(isColliding > 0) && other.name == "CheckpointTwoCollider" && this.tag == "PlayerShip" && errorFlag)
        {
            isColliding++;
            errorFlag = false;
            Debug.Log(isColliding + " Counted in error 2");
            if (isColliding == 1)
            {
                throwError();
            }
        }
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter != 3 && !(isColliding > 0) && other.name == "CheckpointThreeCollider" && this.tag == "PlayerShip" && errorFlag)
        {
            isColliding++;
            errorFlag = false;
            Debug.Log(isColliding + " Counted in error 3");
            if (isColliding == 1)
            {
                throwError();
            }
        }

        //FinishLine
        if (this.gameObject.GetComponent<Collider>().isTrigger && (correctCheckpointCounter-1) == checkpointsTotal && !(isColliding > 0) && other.name == "FinishLineCollider" && this.tag == "PlayerShip" && other.tag == "FinishLine")
        {
            errorFlag = true;
            error = false;
            isCollidingFlag = false;
            checkpointsCounter = 0;
            correctCheckpointCounter = 1;
            Destroy(destroyWaypoint);
            Debug.Log("FINISHED");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Checkpoint" && this.tag == "PlayerShip")
        {
            if(isColliding > 0)
            {
                isColliding--;
                isCollidingFlag = true;
                Debug.Log(isColliding + " Counted down on exit");
            }
            if (isColliding == 0 && isCollidingFlag)
            {
                isColliding = 0;
                isCollidingFlag = false;
                errorFlag = true;
                if (error)
                {
                    checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + " / " + checkpointsTotal;
                    error = false;
                }
                Debug.Log(isColliding + " is zero'd out");
            }
        }
    }

    private void updateCounter()
    {
        correctCheckpointCounter++;
        Debug.Log("CheckpointCounter is now " + correctCheckpointCounter);
        checkpointsCounter++;
        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + " / " + checkpointsTotal;
    }

    private void throwError()
    {
        checkpointText.text = "ERROR";
        Debug.Log("i threw an error");
        error = true;
    }

    public void ResetToLastCheckpoint()
    {
        if(correctCheckpointCounter == 1)
        {
            self.position = resets[0].position;
            self.rotation = resets[0].rotation;
        }
        else if(correctCheckpointCounter == 2)
        {
            self.position = resets[1].position;
            self.rotation = resets[1].rotation;
        }
        else if (correctCheckpointCounter == 3)
        {
            self.position = resets[2].position;
            self.rotation = resets[2].rotation;
        }
    }
}

// WORKING CODE JUST IN CASE!
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CheckpointCounter : MonoBehaviour
//{
//    public int checkpointsTotal = 0;
//    public static int checkpointsCounter = 0;
//    public Text checkpointText;
//    private static int correctCheckpointCounter = 1;
//    private int isColliding = 0;
//    private static bool error = false;
//    private static bool isCollidingFlag = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip")
//        {
//            isColliding++;
//            Debug.Log(isColliding);
//            if (isColliding == 1)
//            {
//                updateCounter();
//            }

//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.tag == "Checkpoint" && this.tag == "PlayerShip")
//        {
//            if (isColliding > 0)
//            {
//                isColliding--;
//                isCollidingFlag = true;
//                Debug.Log(isColliding);
//            }
//            if (isColliding == 0 && isCollidingFlag)
//            {
//                isColliding = 0;
//                isCollidingFlag = false;
//                if (error)
//                {
//                    checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//                    error = false;
//                }
//                Debug.Log(isColliding + " is zero'd out");
//            }
//        }
//    }

//    private void updateCounter()
//    {
//        correctCheckpointCounter++;
//        Debug.Log("CheckpointCounter is now " + correctCheckpointCounter);
//        checkpointsCounter++;
//        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//    }

//    private void throwError()
//    {
//        checkpointText.text = "ERROR";
//        Debug.Log("i threw and error");
//        error = true;
//    }
//}

//WORKING WITH ERROR
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CheckpointCounter : MonoBehaviour
//{
//    public int checkpointsTotal = 0;
//    public static int checkpointsCounter = 0;
//    public Text checkpointText;
//    private static int correctCheckpointCounter = 1;
//    private int isColliding = 0;
//    private static bool error = false;
//    private static bool isCollidingFlag = false;
//    private static bool errorFlag = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //true (no error)
//        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip")
//        {
//            isColliding++;
//            Debug.Log(isColliding);
//            if (isColliding == 1)
//            {
//                updateCounter();
//            }

//        }

//        //false(error)
//        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter > 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip" && errorFlag)
//        {
//            isColliding++;
//            errorFlag = false;
//            Debug.Log(isColliding);
//            if (isColliding == 1)
//            {
//                throwError();
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.tag == "Checkpoint" && this.tag == "PlayerShip")
//        {
//            if (isColliding > 0)
//            {
//                isColliding--;
//                isCollidingFlag = true;
//                Debug.Log(isColliding);
//            }
//            if (isColliding == 0 && isCollidingFlag)
//            {
//                isColliding = 0;
//                isCollidingFlag = false;
//                errorFlag = true;
//                if (error)
//                {
//                    checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//                    error = false;
//                }
//                Debug.Log(isColliding + " is zero'd out");
//            }
//        }
//    }

//    private void updateCounter()
//    {
//        correctCheckpointCounter++;
//        Debug.Log("CheckpointCounter is now " + correctCheckpointCounter);
//        checkpointsCounter++;
//        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
//    }

//    private void throwError()
//    {
//        checkpointText.text = "ERROR";
//        Debug.Log("i threw an error");
//        error = true;
//    }
//}