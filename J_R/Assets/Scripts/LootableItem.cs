using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LootableItem : MonoBehaviour 
{
    private Text LootDebug;
    private List<string> ItemsInLootableItem = new List<string>();
    public string LootableItemName;
    private LootManager LootManager;
    public string GetLootableItemName()
    {
        return LootableItemName;
    }
	void Start () 
    {
        LootManager = GameObject.Find("Camera").GetComponent<LootManager>();
        LootDebug = GameObject.Find("LootDebug").GetComponent<Text>();
	}
    public void OnMouseDown()
    {
        ItemsInLootableItem = new List<string>();
        LootDebug.text = "LOOT DEBUG:";
        int RandomizedItemAmount = LootManager.ItemsInLootableObject(gameObject.name);
        // Something will happen in UI here ( Screen Overlay )
        if (RandomizedItemAmount != 0)
        {
            for (int i = 0; i < RandomizedItemAmount; i++)
            {
                ItemsInLootableItem.Add(LootManager.FindItemInLootableObject(gameObject.name));
            }
        }
        LootDebug.text += "\n" + gameObject.name + " opened!" + "\n" + "Found "  + RandomizedItemAmount + " item(s)!";
        for (int i = 0; i < ItemsInLootableItem.Count; i++)
        {
            LootDebug.text += "\n" + (i + 1) + ". " + ItemsInLootableItem[i];
        }
    }
}
