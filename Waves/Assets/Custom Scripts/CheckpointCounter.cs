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
    private static bool errorFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
    }

    private void OnTriggerEnter(Collider other)
    {
        //true (no error)
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter == 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip")
        {
            isColliding++;
            Debug.Log(isColliding);
            if(isColliding == 1){
                updateCounter();
            }
            
        }

        //false(error)
        if (this.gameObject.GetComponent<Collider>().isTrigger && correctCheckpointCounter > 1 && other.name == "CheckpointOneCollider" && this.tag == "PlayerShip" && errorFlag)
        {
            isColliding++;
            errorFlag = false;
            Debug.Log(isColliding);
            if (isColliding == 1)
            {
                throwError();
            }
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
                Debug.Log(isColliding);
            }
            if (isColliding == 0 && isCollidingFlag)
            {
                isColliding = 0;
                isCollidingFlag = false;
                errorFlag = true;
                if (error)
                {
                    checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
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
        checkpointText.text = "Checkpoints" + "\n" + checkpointsCounter + "/" + checkpointsTotal;
    }

    private void throwError()
    {
        checkpointText.text = "ERROR";
        Debug.Log("i threw an error");
        error = true;
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