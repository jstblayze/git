using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LootableObject : MonoBehaviour 
{
    private bool IsLooted;
    private Text LootDebug;
    public List<string> ItemsInLootableObject = new List<string>();
    private string LootableObjectName;
    private LootManager LootManager;
    private LootableInventory Inventory;
	void Start () 
    {
        LootManager = GameObject.Find("Camera").GetComponent<LootManager>();
        LootDebug = GameObject.Find("LootDebug").GetComponent<Text>();
        IsLooted = false;
        LootableObjectName = gameObject.name;
        Inventory = GameObject.Find("Camera").GetComponent<LootableInventory>(); // will change to player later
	}
    public string GetLootableObjectName()
    {
        return LootableObjectName;
    }
    public void ResetItems()
    {
        ItemsInLootableObject.Clear();
    }
    public bool HasBeenLooted()
    {
        return IsLooted;
    }
    public void SetLooted(bool Looted)
    {
        IsLooted = Looted;
    }
    public void OnMouseDown()
    {
        LootManager.ResetInventoryScreen();
        if (!IsLooted)
        {
            LootDebug.text = "LOOT DEBUG:";
            int RandomizedItemAmount = LootManager.ItemsInLootableObject(gameObject.name);
            // Something will happen in UI here ( Screen Overlay )
            if (RandomizedItemAmount != 0)
            {
                for (int i = 0; i < RandomizedItemAmount; i++)
                {
                    ItemsInLootableObject.Add(LootManager.FindItemInLootableObject(gameObject.name));
                }
            }
            LootDebug.text += "\n" + gameObject.name + " opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
            for (int i = 0; i < ItemsInLootableObject.Count; i++)
            {
                //LootDebug.text += "\n" + (i + 1) + ". " + ItemsInLootableObject[i];
                Inventory.AddToCanvas(ItemsInLootableObject[i]);
            }
            LootManager.AddToOpenedLootList(this);
            IsLooted = true;
        }
        else
        {
            LootDebug.text = "LOOT DEBUG:";
            LootDebug.text += "\n" + gameObject.name + " re-opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
            for (int i = 0; i < ItemsInLootableObject.Count; i++)
            {
                //LootDebug.text += "\n" + (i + 1) + ". " + ItemsInLootableObject[i];
                Inventory.AddToCanvas(ItemsInLootableObject[i]);
            }
        }
    }
}
