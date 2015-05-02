// Author: Amina Khalique
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class LootableObject : MonoBehaviour 
{
    private bool IsLooted;
    private Text LootDebug;
    public List<string> ItemsInLootableObject = new List<string>();
    private string LootableObjectName;
    private GameManager GameManager;
    public GameObject LootPrompt;
	void Start () 
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LootDebug = GameObject.Find("LootDebug").GetComponent<Text>();
        IsLooted = false;
        LootableObjectName = gameObject.name;
	}
    void Update()
    {
       // Makes the object glow when it's in camera/ player view :)
       Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
       if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
       {
           ToggleHalo(true);
       }
       else
       {
           ToggleHalo(false);
       }
    }
    public void TogglePlayerInLootingRange(bool Toggle)
    {
        switch(Toggle)
        {
            case true:
                LootPrompt.SetActive(true);
                LootPrompt.GetComponentInChildren<Text>().text = "Open " + gameObject.name;
                GameManager.ObjectInLootingRange = Toggle;
                GameManager.ObjectInLootRange = this;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case false:
                LootPrompt.GetComponentInChildren<Text>().text = "";
                LootPrompt.SetActive(false);
                GameManager.ObjectInLootingRange = Toggle;
                GameManager.ObjectInLootRange = null;
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }
    public void ToggleHalo(bool Toggle)
    {
        Behaviour h = (Behaviour)GetComponent("Halo");
        h.enabled = Toggle;
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
    public void RemoveFromLoot(string ItemName)
    {
        int IndexToRemove = -1;
        for(int i = 0; i < ItemsInLootableObject.Count; i++)
        {
            if(ItemsInLootableObject[i] == ItemName)
            {
                IndexToRemove = i;
            }
        }
        if(IndexToRemove != -1)
        {
            ItemsInLootableObject.RemoveAt(IndexToRemove);
        }
    }
    public void OnBeingLooted() // Would change to On Object Opened
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
                foreach (string s in ItemsInLootableObject)
                {
                    Debug.Log(s);
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
