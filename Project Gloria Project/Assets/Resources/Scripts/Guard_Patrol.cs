using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Patrol : MonoBehaviour
{
    bool dir;
    public float maxDistance;
    public float minDistance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        dir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); ;
        }
        else
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }

        if (transform.position.x > maxDistance)
        {
            dir = false;
        }
        else if(transform.position.x < minDistance)
        {
            dir = true;
        }

    }
}
