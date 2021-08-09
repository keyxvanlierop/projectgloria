using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Up : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.2f, 0);

        if(transform.position.y > 44f)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
