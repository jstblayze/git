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
    private GameManager GameManager;
	void Start () 
    {
        //gameObject.GetComponent("Halo").GetType().GetProperty("enabled").SetValue(gameObject.GetComponent("halo"), false, null);

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LootDebug = GameObject.Find("LootDebug").GetComponent<Text>();
        IsLooted = false;
        LootableObjectName = gameObject.name;
	}
    public void ToggleHalo(bool Toggle)
    {
        //gameObject.GetComponent("Halo").GetType().GetProperty("enabled").SetValue(gameObject.GetComponent("halo"), Toggle, null);
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
    public void OnMouseDown() // Would change to On Object Opened
    {
        GameManager.GetLootableInventoryPanel().SetNoItems(false);
        GameManager.GetLootScreen().SetActive(true);
        GameManager.CurrentlyActiveUI = Enums.ActiveUI.LootScreen;
        GameManager.LootManager.ResetInventoryScreen();
        if (!IsLooted)
        {
            LootDebug.text = "LOOT DEBUG:";
            int RandomizedItemAmount = GameManager.LootManager.ItemsInLootableObject(gameObject.name);
            if (RandomizedItemAmount != 0)
            {
                GameManager.GetLootableInventoryPanel().SetNoItems(false);
                for (int i = 0; i < RandomizedItemAmount; i++)
                {
                    ItemsInLootableObject.Add(GameManager.LootManager.FindItemInLootableObject(gameObject.name, ItemsInLootableObject));
                }
            }
            else
            {
                GameManager.GetLootableInventoryPanel().SetNoItems(true);
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
            if(ItemsInLootableObject.Count == 0)
            {
                GameManager.GetLootableInventoryPanel().SetNoItems(true);
            }
            else
            {
                for (int i = 0; i < ItemsInLootableObject.Count; i++)
                {
                    GameManager.LootableInventoryScreen.AddToCanvas(ItemsInLootableObject[i]);
                }
            }
        }
    }
}
