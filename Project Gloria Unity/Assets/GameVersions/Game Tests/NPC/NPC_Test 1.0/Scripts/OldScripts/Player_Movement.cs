using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    float speed;
    int direction;
   
    // Use this for initialization
    void Start () {
        speed = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {

        // Ik wil hier eigenlijk diagonal speed oplossen
        //Debug.Log(speed * direction * Time.deltatime);



        if (Input.GetKey(KeyCode.W))
        {
           
            transform.Translate(0, 0, speed);
        }
     
        if (Input.GetKey(KeyCode.S))
        {
            
            transform.Translate(0, 0, -speed);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Translate(-speed, 0 ,0);
        }
       
        if (Input.GetKey(KeyCode.D))
        {
           
            transform.Translate(speed, 0, 0);
        }
       
      

       
    }
}
