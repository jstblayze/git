// Author : Amina Khalique 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LootManager : MonoBehaviour
{
    public Text LootDebug;

    List<LootableObject> OpenedLootableObjects = new List<LootableObject>();

    private Dictionary<string, int[]> ItemCountRandomizerDB = new Dictionary<string,int[]>();
    private Dictionary<string, ItemChanceData[]> ItemChanceDB = new Dictionary<string, ItemChanceData[]>();
    private Dictionary<string, InventoryItemData> ItemDataDB = new Dictionary<string, InventoryItemData>();
    
    void Awake()
    {
        // Create Item Data Database
        ItemDataDB.Add("Pistol", new InventoryItemData("Pistol", "It's a gun you dumbass", "10 Pistol Bullets"));
        ItemDataDB.Add("Rifle", new InventoryItemData("Rifle", "Something I'd like to shoot you with right now", "20 Rifle Ammo"));
        ItemDataDB.Add("MachineGun", new InventoryItemData("MachineGun", "Jesus can you stop waving that thing around?!", "Machine Gun Ammo"));
        ItemDataDB.Add("Vaccine1", new InventoryItemData("Vaccine1", "It cures your health/infection", "Costs 20HP to use if your Ryley and costs 500,000 to use if you're jackson LOL jk"));

        //Position Corresponds to item count                 0  1   2   3   4 
        ItemCountRandomizerDB.Add("Enemy_Tiger", new int[] { 0, 25, 45, 20, 10 }); 
        ItemCountRandomizerDB.Add("Enemy_Lizard", new int[] { 0, 25, 50, 20, 5 });
        ItemCountRandomizerDB.Add("Enemy_Gecko", new int[] { 0, 25, 50, 20, 5 });
        ItemCountRandomizerDB.Add("Container_Locker", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Container_DeskDrawer", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Container_MedicalKit", new int[] { 20, 20, 20, 20, 20 });

        // Create Item Chance Database
        // Tiger
        ItemChanceDB.Add("Enemy_Tiger", new ItemChanceData [] 
        {
            new ItemChanceData("Pistol", 40), // 40% Chance there's a pistol on a Tiger Enemy
            new ItemChanceData("PistolBullets", 30),
            new ItemChanceData("Vaccine1",15),
            new ItemChanceData("Vaccine2",15)
        });
        // Gecko
        ItemChanceDB.Add("Enemy_Gecko", new ItemChanceData[] 
        {
            new ItemChanceData("Pistol", 15),
            new ItemChanceData("MachineGun", 40),
            new ItemChanceData("MachineGunBullets",20),
            new ItemChanceData("Vaccine1",20),
            new ItemChanceData("Vaccine2",5)
        }); 
        // Lizard
        ItemChanceDB.Add("Enemy_Lizard", new ItemChanceData[] 
        {
            new ItemChanceData("Pistol", 5),
            new ItemChanceData("Rifle", 25),
            new ItemChanceData("RifleBullets",10),
            new ItemChanceData("Vaccine1",30),
            new ItemChanceData("Vaccine2",20)
        }); 
        // Medical Kit - Only find vaccines
        ItemChanceDB.Add("Container_MedicalKit", new ItemChanceData[] 
        {
            new ItemChanceData("Vaccine1",65),
            new ItemChanceData("Vaccine2",35)
        }); 

        // Locker - Only find weapons & Bullets 
        ItemChanceDB.Add("Container_Locker", new ItemChanceData[] 
        {
            new ItemChanceData("Pistol", 20),
            new ItemChanceData("PistolBullets", 30),
            new ItemChanceData("MachineGun",15),
            new ItemChanceData("MachineGunBullets",20),
            new ItemChanceData("Rifle",5),
            new ItemChanceData("RifleBullets", 10)
        }); 
        // Desk Drawer - Only find Bullets, Keys, Vaccines
        ItemChanceDB.Add("Container_DeskDrawer", new ItemChanceData[] 
        {
            new ItemChanceData("PistolBullets", 30),
            new ItemChanceData("MachineGunBullets",20),
            new ItemChanceData("RifleBullets", 10),
            new ItemChanceData("Zone_A_Key", 25),
            new ItemChanceData("Vaccine1", 10),
            new ItemChanceData("Vaccine2", 5)
        });

       
    }
    public void AddToOpenedLootList(LootableObject LootableObject)
    {
        OpenedLootableObjects.Add(LootableObject);
    }
    public void ResetInventoryScreen()
    {
        List<GameObject> Children = new List<GameObject>();
        foreach (Transform Child in (GameManager.LootableInventoryScreen.GetComponentInChildren<Transform>()))
        {
            Children.Add(Child.gameObject);
        }
        foreach (GameObject Child in Children)
        {
            Destroy(Child);
        }
    }
    public void ResetAllOpenedLoot()
    {
        ResetInventoryScreen();
        foreach (LootableObject LootObject in OpenedLootableObjects)
        {
            LootObject.SetLooted(false);
            LootObject.ResetItems();
        }
        OpenedLootableObjects = new List<LootableObject>();
        //LootDebug.text = "LOOT DEBUG";
    }
    public string GetItemStats(string ItemName)
    {
        InventoryItemData InventoryItemData;
        ItemDataDB.TryGetValue(ItemName, out InventoryItemData);
        return InventoryItemData.GetStats();
    }
    public string GetItemDescription(string ItemName)
    {
        InventoryItemData InventoryItemData;
        ItemDataDB.TryGetValue(ItemName, out InventoryItemData);
        return InventoryItemData.GetDescription();
    }
    public InventoryItemData GetItemData(string ItemName)
    {
        InventoryItemData InventoryItemData;
        ItemDataDB.TryGetValue(ItemName, out InventoryItemData);
        return InventoryItemData;
    }
    public int ItemsInLootableObject(string LootableObjectName) 
    {
        int NumberOfItemsInLoot = -1;
        int[] RandomItemCount;
        ItemCountRandomizerDB.TryGetValue(LootableObjectName, out RandomItemCount);
        int Range = 0;   
        if(RandomItemCount != null && RandomItemCount.Length > 0)
        {
            for (int i = 0; i < RandomItemCount.Length; i++)
            {
                Range += RandomItemCount[i];
            }
            int Chance = Random.Range(0, Range); // 100 %
            int Top = 0;
            for (int i = 0; i < RandomItemCount.Length; i++)
            {
                Top += RandomItemCount[i];
                if (Chance < Top)
                {
                    NumberOfItemsInLoot = i;
                    break;
                }
            }
        }
        return NumberOfItemsInLoot;
    }
    public string FindItemInLootableObject(string LootableObjectName) 
    {
        string ItemToReturn = "";
        ItemChanceData[] ItemChances;
        ItemChanceDB.TryGetValue(LootableObjectName, out ItemChances);

        int Range = 0;
        if (ItemChances != null && ItemChances.Length > 0)
        {
            for (int i = 0; i < ItemChances.Length; i++)
            {
                Range += (int)ItemChances[i].GetLootChance(); 
            }
            int Chance = Random.Range(0, Range);
            int Top = 0;
            for (int i = 0; i < ItemChances.Length; i++)
            {
                Top += (int)ItemChances[i].GetLootChance();
                if (Chance < Top)
                {
                    ItemToReturn = ItemChances[i].GetItemName();
                    break;
                }
            }
        }
        return ItemToReturn;
    }
}