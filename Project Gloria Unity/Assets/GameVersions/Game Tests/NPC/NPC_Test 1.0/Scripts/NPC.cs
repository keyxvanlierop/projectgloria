using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;





/*NPC zoekt de nabijste winkel met eten. Als het op is scant hij nogmaals zolang er winkels zijn */
//schrijf de keuze voor naar de pilaar tussendoor
//schrijf de afweging om er wel of niet naartoe te gaan
//HP fear faithless
//schrijf een script voor de slap


public class NPC : MonoBehaviour
{

    //References
    NavMeshAgent _navMeshAgent;
    public Transform _destination;
    GameObject _gameManagerObject;

    //Memories
   
    public Transform homePosition;
    public Transform storePosition; 
    public int HP;
    public bool hasFood;
    enum Action {idle,toStore,toHome};
    Action myAction;
    
    public int noFoodCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        //Fill References
        homePosition = GameObject.Find("House").transform;
        _gameManagerObject = GameObject.Find("GameManager");        
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        

        //Fill Memories
        myAction = Action.toStore;
        HP = 100;
        hasFood = false;

        //Fire Functions
        CheckAndSetClosestStore(transform.position, 100);
        SetDestination();
        updateHP(0);
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    
    void SetDestination() //Deze functie checkt welke eindpunt de NPC heeft, verandert de value en update het nieuwe eindpunt
    {        
        
          if(GetComponent<NavMeshAgent>().enabled == true)
        {
            if (myAction == Action.toHome)
            {
                _destination = homePosition;
            }
            else if (myAction == Action.toStore)
            {
                _destination = storePosition;
            }
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            if (myAction == Action.idle)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                transform.position = new Vector3(0, 0, -11);
                updateHP(-10);
                _gameManagerObject.GetComponent<game_manager>().numberOfVillagersDoneWithDay++;
            }
        }
    }


    void CheckAndSetClosestStore(Vector3 center, float radius) 
        /*Zoekt in de layer "mask" naar de dichbijzijnste stores in de radius die je meegeeft en vult 
        de variable storePosition met de naam van de meest nabije winkel */
    {
        LayerMask mask;
        mask = LayerMask.GetMask("Stores");
        

        Collider[] hitColliders = Physics.OverlapSphere(center, radius, mask);
        float oldDistance = 0.0f;
        string tempClosestStoreName = null;
        foreach (var hitCollider in hitColliders)
        {               
            float newDistance = Vector3.Distance(transform.position, hitCollider.transform.position);
            int amountFood = hitCollider.GetComponent<Store>().food;
            StoreHasFood(amountFood);

            if (hasFood == true) {
                if (oldDistance == 0 || oldDistance > newDistance)
                {
                    
                    tempClosestStoreName = hitCollider.name;
                    oldDistance = newDistance;
                }
            }           
           
        }  
        if(noFoodCounter == GameObject.FindGameObjectsWithTag("store").Length){
            myAction = Action.toHome;
            SetDestination();
        } else {
            storePosition = GameObject.Find(tempClosestStoreName).transform;
            _destination = storePosition;
            SetDestination();
            noFoodCounter = 0;
        }
           
    }
    //A new day is being started for the NPC. He gets put back at his house.
    public void newDay()
    {
        transform.position = homePosition.position;
        GetComponent<NavMeshAgent>().enabled = true;
        CheckAndSetClosestStore(transform.position,100);
        myAction = Action.toStore;
        SetDestination();
    }

    void updateHP(int value)
    {
        HP += value;
        if(HP >= 80)
        {
            ChangeColorToHP("green");
        }else if(HP < 80 && HP >= 30)
        {
            ChangeColorToHP("orange");
        }
        else if(HP < 30 && HP >= 1)
        {
            ChangeColorToHP("red");
        } else  if(HP < 1)
        {
            Destroy(this.gameObject);
        }
    }

   void StoreHasFood(int amountFood)
    {   

        
        if (amountFood > 0)
        {
            hasFood = true;
        }
        else
        {
            hasFood = false;
            noFoodCounter++;
        }
    }
     



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "store" && other.gameObject.GetComponent<Store>().food > 0 )
        {
            other.gameObject.GetComponent<Store>().food -= 10;
            myAction = Action.toHome;
            SetDestination();
        }else if(_destination != homePosition){
            CheckAndSetClosestStore(transform.position, 50);
        }

        if(other.gameObject.tag == "house" && myAction == Action.toHome)
        {
            myAction = Action.idle;
            SetDestination();
        }
        
    }

    void ChangeColorToHP(string value)
    {
        switch (value)
        {
            case "green":
                // code block
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case "orange":
                Color color = new Color(1.0f, 0.55f, 0);                
                gameObject.GetComponent<Renderer>().material.color = color;
                // code block
                break;
            case "red":
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                // code block
                break;
           
        }
        

        

        
    }




    /*
    public int HP;
    public int fearfull;
    public int faithfull;
    public Transform statuePosition;
    */


    /*
        HP = 100;
        fearfull = 0;
        faithfull = Random.Range(0, 100);
        doneWithTheDay = false;
        */





    /*
    void ChangeFear(int i)
    {
        fearfull =+ i;
    }

    void ChangeHP(int i)
    {
        HP =+ i;
    }

    void CalculateTimeToDead()
    {

    }
    */
}
