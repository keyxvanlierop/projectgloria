using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_AI : MonoBehaviour {
    string role;
    int interest;
    bool occupied;
    bool moving;
    Vector3 target;
    float speed = 5f;
    float step;
    GameObject manager;
    // Use this for initialization
    void Start () {
        //role bepaald wat je interessant vindt
        role = "villager";
        occupied = false;
        moving = false;
        manager = GameObject.Find("GameManager");
	}

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        

        if (role == "villager"){
             if (occupied == false && moving == false)
             {
                 occupied = true;
                 interest = Random.Range(0, 3);
                    
                 if (interest == 0)
                 {
                     target = new Vector3(-4.06f, 0, -1.11f);
                    manager.GetComponent<game_manager>().updateDays(10);
                 }
                 else if (interest == 1)
                 {
                     target = new Vector3(0, 0, 3.92f);
                    manager.GetComponent<game_manager>().updateDays(10);
                }
                 else if( interest == 2)
                 {
                    target = new Vector3(4.16f, 0, -2.87f);
                    manager.GetComponent<game_manager>().updateDays(10);
                }                
             }
         }



        if (transform.position != target)
        {
            moving = true;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

        }
        else
        {
            occupied = false;
            moving = false;
        }
    }
}
