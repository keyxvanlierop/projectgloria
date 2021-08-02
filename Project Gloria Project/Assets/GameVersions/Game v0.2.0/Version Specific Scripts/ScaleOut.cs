using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleOut : MonoBehaviour
{
    
    
    bool light;

    // Start is called before the first frame update
    void Start()
    {
        light = false;
        StartCoroutine(ExecuteAfterTime(5));
    }

    // Update is called once per frame
    void Update()
    {
        if (light == true)
        {
            GetComponent<Text>().color = Color.clear;
           
        }
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        
        yield return new WaitForSeconds(time);
        light = true;

        // Code to execute after the delay
    }

}
