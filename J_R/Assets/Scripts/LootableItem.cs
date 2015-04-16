using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootableItem : MonoBehaviour 
{
    private List<string> ItemsInLootableItem = new List<string>();
    public string LootableItemName;
    private LootManager LootManager;

    public string GetLootableItemName()
    {
        return LootableItemName;
    }
    public void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.name.Contains("LootTrigger")) // Would be changed to - If action button is pressed while item is in focus
        {
            int RandomizedItemAmount = LootManager.ItemsInLootableObject(gameObject.name);
            // Something will happen in UI here ( Screen Overlay )
            Debug.Log(gameObject.name + " opened!");
            if (RandomizedItemAmount != 0)
            {
                for (int i = 0; i < RandomizedItemAmount; i++)
                {
                    ItemsInLootableItem.Add(LootManager.FindItemInLootableObject(gameObject.name));
                }
            }
            Debug.Log("Found " + ItemsInLootableItem.Count + " item(s)!");
            foreach (string Item in ItemsInLootableItem)
            {
                Debug.Log(Item);
            }
        }
    }
	// Use this for initialization
	void Start () 
    {
        LootManager = GameObject.Find("Camera").GetComponent<LootManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
