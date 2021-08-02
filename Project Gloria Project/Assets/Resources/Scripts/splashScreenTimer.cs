using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreenTimer : MonoBehaviour
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
            SceneManager.LoadScene("ProjectGloria_0.2.0");

        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {

        yield return new WaitForSeconds(time);
        light = true;

        // Code to execute after the delay
    }


}
