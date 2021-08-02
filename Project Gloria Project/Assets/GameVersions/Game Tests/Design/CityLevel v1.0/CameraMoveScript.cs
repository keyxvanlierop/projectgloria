using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse Y") > 0)
        {
            transform.Rotate(-2.5f, 0, 0);
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            transform.Rotate(2.5f, 0, 0);
        }
    }
}
