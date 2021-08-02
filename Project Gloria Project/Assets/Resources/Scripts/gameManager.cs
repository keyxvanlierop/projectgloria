using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static int hours;
    int seconds;
    float timeStamp;
    float timeSpeed;



    // Start is called before the first frame update
    void Start()
    {
        hours = 5;
        seconds = 0;
        timeSpeed = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp + timeSpeed < Time.time)
        {
            timeStamp = Time.time;
            if(seconds == 59)
            {
                seconds = 00;
                if (hours == 23)
                {
                    hours = 00;
                }
                else
                {
                    hours++;
                }                
            }
            else
            {
                seconds++;
            }            
        }

        Debug.Log("Hours: " + hours + " Seconds: " + seconds);
    }


  
}
