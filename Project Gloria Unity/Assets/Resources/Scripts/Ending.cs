using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("End");
            GameObject.FindGameObjectWithTag("Respawn").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            this.gameObject.transform.position = new Vector3(4.7f, 43.6f, 22.9f);
        }
    }
}
