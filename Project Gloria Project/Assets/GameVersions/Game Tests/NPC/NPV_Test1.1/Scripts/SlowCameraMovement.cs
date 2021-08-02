using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.0002f, 0.0005f, 0.0005f);
    }
}
