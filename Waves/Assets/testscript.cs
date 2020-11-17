using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    //public Transform This;
    public Transform Other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform target;
        //target.localRotation = Quaternion.Euler(new Vector3(Cube1.localRotation.x, Cube1.localRotation.y, Cube1.localRotation.z));
        //Cube2.localRotation = Quaternion.Euler(new Vector3(Cube1.localRotation.x, Cube1.localRotation.y, Cube1.localRotation.z));

        Vector3 eulerRotation = new Vector3(this.transform.localRotation.eulerAngles.x, Other.transform.localRotation.eulerAngles.z, this.transform.localRotation.eulerAngles.z);

        this.transform.localRotation = Quaternion.Euler(eulerRotation);
    }
}
