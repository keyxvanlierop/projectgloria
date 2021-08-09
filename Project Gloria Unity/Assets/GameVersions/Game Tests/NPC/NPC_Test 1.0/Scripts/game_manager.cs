using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

    //References
    Text daysText;
    public GameObject villagerPrefab;

    //Memories
    public int numberOfDays;
    public int numberOfVillagers;
    public int numberOfVillagersDoneWithDay;
    public int createVillagers;
    Color randomColor;

    public int y;

    public List<GameObject> villagerReferences;
    public List<GameObject> storeReferences;

    // Use this for initialization
    void Start () {

        //Fill References
        daysText = GameObject.Find("DaysValue").GetComponent<Text>();


        //Fire Functions
        NewDayStores();
        updateDays(1);
        CreateVillagers(createVillagers);

        
       
        
    }
	
	// Update is called once per frame
	void Update () {
        CheckAllVillagersDoneWithDay();
        
    }


    void NewDay()
    {
        updateDays(1);
        NewDayStores();
        NewDayForVillagers();        
    }


   public void updateDays(int value)
    {            
            numberOfDays += value;
            daysText.text = numberOfDays.ToString();
        
    }
    void CreateVillagers(int other)//Opgeloste bug: Als de villager te dicht bij de store wordt gespawnt geeft hij een foutmelding ivm de homePosition
    {
        for (int i = 0; i < other; i++)
        {
            float xPos = Random.Range(-3.5f, 3.5f);
            float zPos = Random.Range(-3.5f, 3.5f);
            Vector3 posVillager = new Vector3(xPos, 0, zPos);
            GameObject villager = Instantiate(villagerPrefab, posVillager, transform.rotation) as GameObject;
                       
        }
        villagerReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("villager"));
        storeReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("store"));
        numberOfVillagers = villagerReferences.Count;
    }
    
    void NewDayStores() //Game doesnt work with one villager cause no food is distributed
    {
        int x = numberOfVillagers;
        int y = (x * 10) - 10;
        while(y > 0) {
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

    void NewDayForVillagers()
    {
        foreach (GameObject villager in villagerReferences)
        {
            villager.GetComponent<NPC>().newDay();
        }
    }



    //Triggers
    void CheckAllVillagersDoneWithDay()
    {
        if(numberOfVillagers == numberOfVillagersDoneWithDay)
        {
            numberOfVillagersDoneWithDay = 0;
            villagerReferences = new List<GameObject>(GameObject.FindGameObjectsWithTag("villager"));
            NewDay();
            
        }
    }
    
}
