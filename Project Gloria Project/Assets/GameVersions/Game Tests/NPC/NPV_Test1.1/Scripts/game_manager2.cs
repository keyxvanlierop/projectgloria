using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager2 : MonoBehaviour
{
    public int startingVillagers; //Number of villagers at the start of the game
    public int numberOfVillagers; // How many villagers are in the game
    public int numberOfVillagersDoneWithDay;

    public GameObject villagerPrefab;
    public List<GameObject> storeReferences;
    public List<GameObject> villagerReferences;


    // Start is called before the first frame update
    void Start()
    {
        storeReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("store"));
        CreateVillagers(startingVillagers);
        SupplyStores();
        StartDayVillagers();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAllVillagersDoneWithDay();
    }

    void CreateVillagers(int other) //Generate and place villagers random on the level
    {
        for (int i = 0; i < other; i++)
        {
            float xPos = Random.Range(-3.5f, 3.5f);//nodig?
            float zPos = Random.Range(-3.5f, 3.5f);
            Vector3 posVillager = new Vector3(xPos, 0, zPos);
            GameObject villager = Instantiate(villagerPrefab, posVillager, transform.rotation) as GameObject;

        }
    }

    void SupplyStores()
    {
        SetNumberOfVillagers();
        int x = numberOfVillagers;
        int y = (x * 10) - 10;
        while (y > 0)
        {
            foreach (GameObject store in storeReferences)
            {
                int z = Random.Range(0, 2);
                if (z == 0)
                {
                    y = y - 10;
                    if (y >= 0)
                    {
                        store.GetComponent<Store>().updateFood(10);
                    }
                }
            }
        }
    }

    void SetNumberOfVillagers()
    {
        villagerReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("villager"));
        numberOfVillagers = villagerReferences.Count;
        
        
    }

    void StartDayVillagers()
    {
        foreach (GameObject villager in villagerReferences)
        {
            villager.GetComponent<NPC2>().newDay();
        }
    }


    void CheckAllVillagersDoneWithDay()
    {
        if (numberOfVillagers == numberOfVillagersDoneWithDay)
        {
            numberOfVillagersDoneWithDay = 0;
            villagerReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("villager"));
            NewDay();

        }
    }

    void NewDay()
    {
        //updateDays(1);
        SupplyStores();
        StartDayVillagers();
    }


}
