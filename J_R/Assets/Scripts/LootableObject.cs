// Author: Amina Khalique
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
	void Start () 
    {
        LootDebug = GameObject.Find("LootDebug").GetComponent<Text>();
        IsLooted = false;
        LootableObjectName = gameObject.name;
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
        GameManager.LootManager.ResetInventoryScreen();
        if (!IsLooted)
        {
            LootDebug.text = "LOOT DEBUG:";
            int RandomizedItemAmount = GameManager.LootManager.ItemsInLootableObject(gameObject.name);
            if (RandomizedItemAmount != 0)
            {
                for (int i = 0; i < RandomizedItemAmount; i++)
                {
                    ItemsInLootableObject.Add(GameManager.LootManager.FindItemInLootableObject(gameObject.name));
                }
            }
            LootDebug.text += "\n" + gameObject.name + " opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
            for (int i = 0; i < ItemsInLootableObject.Count; i++)
            {
                GameManager.LootableInventoryScreen.AddToCanvas(ItemsInLootableObject[i]);
            }
            GameManager.LootManager.AddToOpenedLootList(this);
            IsLooted = true;
        }
        else
        {
            LootDebug.text = "LOOT DEBUG:";
            LootDebug.text += "\n" + gameObject.name + " re-opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
            for (int i = 0; i < ItemsInLootableObject.Count; i++)
            {
                GameManager.LootableInventoryScreen.AddToCanvas(ItemsInLootableObject[i]);
            }
        }
    }
}
