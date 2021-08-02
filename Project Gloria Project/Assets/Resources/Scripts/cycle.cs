using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cycle : MonoBehaviour
{
    Transform _destination;
    NavMeshAgent _navMeshAgent;
    Transform StatuePosition;
    Transform WorkplacePosition;
    Transform PipePosition;
    Transform HousePosition;


    // Start is called before the first frame update
    void Start()
    {
        StatuePosition = GameObject.Find("Statue").GetComponent<Transform>();
        WorkplacePosition = GameObject.Find("Workplace1").GetComponent<Transform>();
        PipePosition = GameObject.Find("Pipe").GetComponent<Transform>();
        HousePosition = GameObject.Find("House").GetComponent<Transform>();



        _navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent  component is not attached to " + gameObject);
        }
        else
        {
            SetDestination();
        }
        
    }
    
    private void SetDestination()
    {
        if(_destination != null)
        {
            Debug.Log("werkt");
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(gameManager.hours == 6)
        {
            _destination = StatuePosition;
            SetDestination();
        }

        if (gameManager.hours == 8)
        {
            _destination = WorkplacePosition;
            SetDestination();
        }

        if (gameManager.hours == 18)
        {
            _destination = PipePosition;
            SetDestination();
        }

        if (gameManager.hours == 20)
        {
            _destination = HousePosition;
            SetDestination();
        }
    }
}
