using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
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
        if (collision.gameObject.tag == "deathpit")
        {
            Debug.Log("Death");
            GameObject.FindGameObjectWithTag("deathUI").GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }
}
