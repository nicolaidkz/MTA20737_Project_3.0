using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knots : MonoBehaviour
{
    public Rigidbody m_rigidbody;

    [Header("UI")]
    public Text speedLabel;

    private float speed = 0;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    private void Update()
    {
        speed = m_rigidbody.velocity.magnitude * 1.944f;

        if (speedLabel != null)
            speedLabel.text = ((float)speed).ToString("F1") + " KN";
    }
}
