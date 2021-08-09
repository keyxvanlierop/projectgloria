using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC2 : MonoBehaviour
{
    //Als de NavmeshAgent allemaal op dezelfde plek starten op hetzelfde moment is er een kans dat ze vast komen te zitten.
    //Ze slaan nu nog stores over als er toch eten is


    NavMeshAgent _navMeshAgent;
    public Transform _destination;
    GameObject _gameManagerObject;

    public Transform homePosition;
    public Transform storePosition;

    bool hasFood;
   public int noFoodCounter;

    enum Action { idle, toStore, toHome };
    Action myAction;

    public int HP;


    // Start is called before the first frame update
    void Awake()
    {
        homePosition = GameObject.Find("House").transform;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _gameManagerObject = GameObject.Find("GameManager");

        HP = 100;

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void newDay()
    {
        float xPos = Random.Range(-3.5f, 3.5f);
        float zPos = Random.Range(-3.5f, 3.5f);
        transform.position = new Vector3(xPos, 0, zPos);        
            
            //homePosition.position;
        GetComponent<NavMeshAgent>().enabled = true;
        CheckForNearestStuffedStore(transform.position, 200);
        //myAction = Action.toStore;
        //SetDestination();
    }

   void CheckForNearestStuffedStore(Vector3 center, float radius)
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

            if (hasFood == true)
            {
                if (oldDistance == 0 || oldDistance > newDistance)
                {

                    tempClosestStoreName = hitCollider.name;
                    oldDistance = newDistance;
                }
            }

        }

        if (noFoodCounter == GameObject.FindGameObjectsWithTag("store").Length)
        {
            myAction = Action.toHome;
            SetDestination();
        }
        else
        {
            storePosition = GameObject.Find(tempClosestStoreName).transform;
            myAction = Action.toStore;
            SetDestination();
            if (true)
            {
                //GameObject.FindGameObjectsWithTag("store").getComponent<Sti
            }
            noFoodCounter = 0;
            
        }        
    }


    




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "store" && other.gameObject.GetComponent<Store>().food > 0)
        {
            other.gameObject.GetComponent<Store>().food -= 10;
            HP += 10;
            myAction = Action.toHome;
            SetDestination();
        }
        else if (_destination != homePosition)
        {
            CheckForNearestStuffedStore(transform.position, 200);
        }

        if (other.gameObject.tag == "house" && myAction == Action.toHome)
        {
            myAction = Action.idle;
            SetDestination();
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

    void SetDestination() //Deze functie checkt welke eindpunt de NPC heeft, verandert de value en update het nieuwe eindpunt
    {

        if (GetComponent<NavMeshAgent>().enabled == true)
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
                HP -= 10;
               _gameManagerObject.GetComponent<game_manager2>().numberOfVillagersDoneWithDay++;
            }
        }
    }



}
