using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    bool runningOn;
    float runningSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        runningOn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
           
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -runningSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * runningSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -runningSpeed * Time.deltaTime);
            
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runningOn = true;
        }
        else
        {
            runningOn = false;
        }
        
        if (runningOn == false)
        {
            runningSpeed = 3f;

        }        else
        {
            runningSpeed = 5f;
        }
        


        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0,-2.5f,0);
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, 2.5f, 0);
        }
    }



    
}
