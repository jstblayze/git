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
    public GameObject LootPrompt;

    private ZoneManager ZM;
	void Start () 
    {
        ZM = GameObject.Find("ZoneManager").GetComponent<ZoneManager>();
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
                ZoneManager.ObjectInLootingRange = Toggle;
                ZoneManager.ObjectInLootRange = this;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case false:
                LootPrompt.GetComponentInChildren<Text>().text = "";
                LootPrompt.SetActive(false);
                ZoneManager.ObjectInLootingRange = Toggle;
                ZoneManager.ObjectInLootRange = null;
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
        if((gameObject.tag.Contains("Enemy") && gameObject.GetComponent<Enemy>().Died())
            ||
            gameObject.tag.Contains("Container")) 
        {
            ZoneManager.GetLootableInventoryPanel().SetNoItems(false);
            ZM.GetLootScreen().SetActive(true);
            ZoneManager.ActiveUI = Enums.ActiveUI.LootScreen;
            GameManager.LootManager.ResetInventoryScreen();
            if (!IsLooted)
            {
                LootDebug.text = "LOOT DEBUG:";
                int RandomizedItemAmount = GameManager.LootManager.ItemsInLootableObject(gameObject.name);
                Debug.Log("Randomized Amount:" + RandomizedItemAmount);
                if (RandomizedItemAmount != 0)
                {
                    ZoneManager.GetLootableInventoryPanel().SetNoItems(false);
                    for (int i = 0; i < RandomizedItemAmount; i++)
                    {
                        ItemsInLootableObject.Add(GameManager.LootManager.FindItemInLootableObject(gameObject.name, ItemsInLootableObject));
                    }
                    Debug.Log(">>>>");
                    foreach (string s in ItemsInLootableObject)
                    {
                        Debug.Log(s);
                    }
                }
                else
                {
                    ZoneManager.GetLootableInventoryPanel().SetNoItems(true);
                }
                LootDebug.text += "\n" + gameObject.name + " opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
                for (int i = 0; i < ItemsInLootableObject.Count; i++)
                {
                    ZoneManager.LootableInventoryScreen.AddToCanvas(ItemsInLootableObject[i]);
                }
                GameManager.LootManager.AddToOpenedLootList(this);
                IsLooted = true;
            }
            else
            {
                LootDebug.text = "LOOT DEBUG:";
                LootDebug.text += "\n" + gameObject.name + " re-opened! -> Found " + ItemsInLootableObject.Count + " item(s)!";
                if (ItemsInLootableObject.Count == 0)
                {
                    ZoneManager.GetLootableInventoryPanel().SetNoItems(true);
                }
                else
                {
                    for (int i = 0; i < ItemsInLootableObject.Count; i++)
                    {
                        ZoneManager.LootableInventoryScreen.AddToCanvas(ItemsInLootableObject[i]);
                    }
                }
            }
        }
    }
}
