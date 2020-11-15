using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class TimerCollider : MonoBehaviour
{
    static public Stopwatch timer;
    public Text text;

    public int errors; //counts errors
    public float timerCooldown; //time between errors
    public int waitTime = 2; //time needed before another error can register

    void Start()
    {
        timer = new Stopwatch(); //create a stopwatch

    }
    void OnCollisionEnter(Collision col) //object entering whatever the start point is, subject to change
    {
        if(col.gameObject.CompareTag("TimerStart"))  //entering the start line collider, start timer
        {
            timer.Start();
            print("Timer Start");
        }
        else if (col.gameObject.CompareTag("TimerStop"))  //entering the end line collider, stop timer
        {
            timer.Stop();
            print("Timer Stopped");
        }
        if (col.gameObject.CompareTag("boundary"))  //entering a collider marked as boundary, basically anything you should not touch when sailing
        {
            if (timerCooldown >= waitTime) //if time between errors has exceeded the waitTime (2), register an error and reset time between errors
            {
                errors++;
                timerCooldown = 0;
            }
        }
    }

    void Update() //updates both stopwatch and cooldown between errors, canvas subject to be removed
    {
        text.text = timer.Elapsed.Seconds.ToString() + ", errors made: " + errors;
        timerCooldown += Time.deltaTime;
    }
}
