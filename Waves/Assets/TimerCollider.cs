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
        if (timerCooldown >= waitTime) //if time between errors has exceeded the waitTime (2), register an error and reset time between errors
        {
            errors++;
            timerCooldown = 0;
            print("Player collided with: " + col.collider.name + " at: " + timer.Elapsed.Seconds); //debug collision name and time
            AppendFile(errors, col.collider.name, timer, "testfile.csv"); //call method, pass information
        }
    }
        void Update() //updates both stopwatch and cooldown between errors, canvas subject to be removed
    {
        text.text = timer.Elapsed.Seconds.ToString() + ", errors made: " + errors;
        timerCooldown += Time.deltaTime;
    }

    public static void AppendFile(int errors, string collision, Stopwatch timer, string filepath)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true)) //create new instance of class, bool true to append and not replace
        {
            file.WriteLine(errors + "," + collision + "," + timer.Elapsed.Seconds); //write errors, collision and timer, ex: 1,Cube,2
        }
    }
}
