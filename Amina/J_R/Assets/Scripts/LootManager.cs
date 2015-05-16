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
        // Weapons
        ItemDataDB.Add("Pistol", new InventoryItemData("Pistol", "It's a gun you dumbass", "10 Pistol Bullets"));
        ItemDataDB.Add("Rifle", new InventoryItemData("Rifle", "Something I'd like to shoot you with right now", "20 Rifle Ammo"));
        ItemDataDB.Add("MachineGun", new InventoryItemData("MachineGun", "Jesus can you stop waving that thing around?!", "Machine Gun Ammo"));
        ItemDataDB.Add("MachineGunBullets", new InventoryItemData("MachineGunBullets", "Dat Machine Gun Bullet Pack yo", "Machine Gun Ammo 30"));
        ItemDataDB.Add("RifleBullets", new InventoryItemData("RifleBullets", "Dat Rifle Bullet Pack yo", "Rifle Ammo 50"));
        ItemDataDB.Add("PistolBullets", new InventoryItemData("PistolBullets", "Dat Pistol Bullet Pack yo", "Pistol Ammo 15"));
        ItemDataDB.Add("Zone_A_Key", new InventoryItemData("Zone_A_Key", "Opens up scifi gate A", "Isn't it pretty?"));
        ItemDataDB.Add("MetalPipe", new InventoryItemData("MetalPipe", "It's a metallic pipe", "It's going to hurt you"));
        ItemDataDB.Add("Reminder", new InventoryItemData("Reminder", "Yeap - Based on Matt", "He's never living it down"));
        ItemDataDB.Add("Knife", new InventoryItemData("Knife", "It's sharp", "Trust me"));
        
        //Items
        ItemDataDB.Add("Vaccine1", new InventoryItemData("Vaccine1", "It cures your health/infection", 
            "I've got a lovely bunch of coconuts, doobey doobey...Health restored!"));
        ItemDataDB.Add("Vaccine2", new InventoryItemData("Vaccine2", "It cures your infection!", 
            "Costs 20HP to use if your Ryley and costs 500,000 to use if you're jackson LOL jk"));
        
        //Maps
        ItemDataDB.Add("Zone1", new InventoryItemData("Zone1", "Map of Zone1", "The one with the enemy hiding in the washroom!"));
        ItemDataDB.Add("Zone2", new InventoryItemData("Zone2", "Map of Zone2", "The one with the shitload of enemies"));
        ItemDataDB.Add("Zone3", new InventoryItemData("Zone3", "Map of Zone3", "The one with a big puddle lol"));
        
        //Position Corresponds to item count                 0  1   2   3   4 
        ItemCountRandomizerDB.Add("Enemy_Tiger", new int[] { 0, 25, 45, 20, 10 });
        ItemCountRandomizerDB.Add("Enemy_Lizard", new int[] { 0, 25, 45, 20, 10 });
        ItemCountRandomizerDB.Add("Enemy_Gecko", new int[] { 0, 25, 45, 20, 10 });
        ItemCountRandomizerDB.Add("Container_Locker", new int[] { 0, 25, 45, 20, 10 });
        ItemCountRandomizerDB.Add("Container_DeskDrawer", new int[] { 0, 25, 45, 20, 10 });
        ItemCountRandomizerDB.Add("Container_MedicalKit", new int[] { 0, 25, 45, 20, 10 }); 

        // Create Item Chance Database - Based on character >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // If you find an item that cannot be duplicated - 
        // - return the item that can be duplicated - that has the highest chance of duplicating instead
        // Tiger
        if(GameManager.CharacterSelected == Enums.Character.Jackson)
        {
            ItemChanceDB.Add("Enemy_Tiger", new ItemChanceData[] 
            {
                new ItemChanceData("Pistol", 40, false, 
                    new ItemChanceData("PistolBullets", 30, true, null)), // 40% Chance there's a pistol on a Tiger Enemy
                new ItemChanceData("PistolBullets", 30, true, null),
                new ItemChanceData("Vaccine1",15, true, null),
                new ItemChanceData("Vaccine2",15, true, null)
            });
            // Gecko
            ItemChanceDB.Add("Enemy_Gecko", new ItemChanceData[] 
            {
                new ItemChanceData("Pistol", 15, false, 
                    new ItemChanceData("MachineGunBullets", 20, true, null)),
                new ItemChanceData("MachineGun", 40, false,
                    new ItemChanceData("Vaccine1", 20, true, null)),
                new ItemChanceData("MachineGunBullets",20, true, null),
                new ItemChanceData("Vaccine1",20, true, null),
                new ItemChanceData("Vaccine2",5, true, null)
            });
            // Lizard
            ItemChanceDB.Add("Enemy_Lizard", new ItemChanceData[] 
            {
                new ItemChanceData("Pistol", 5, false,
                    new ItemChanceData("Vaccine1", 30, true, null)),
                new ItemChanceData("Rifle", 25, false, 
                    new ItemChanceData("Vaccine2", 20, true, null)),
                new ItemChanceData("RifleBullets", 10, true, null),
                new ItemChanceData("Vaccine1",30, true, null),
                new ItemChanceData("Vaccine2",20, true, null)
            });
            // Medical Kit - Only find vaccines
            ItemChanceDB.Add("Container_MedicalKit", new ItemChanceData[] 
            {
                new ItemChanceData("Vaccine1",65, false, 
                    new ItemChanceData("Vaccine2", 35, true, null)),
                new ItemChanceData("Vaccine2",35, true, null)
            });

            // Locker - Only find weapons & Bullets 
            ItemChanceDB.Add("Container_Locker", new ItemChanceData[] 
            {
                new ItemChanceData("Pistol", 20, false,
                    new ItemChanceData("PistolBullets", 30, true, null)),
                new ItemChanceData("PistolBullets", 30, true, null),
                new ItemChanceData("MachineGun",15, false, 
                    new ItemChanceData("RifleBullets", 10, true, null)),
                new ItemChanceData("MachineGunBullets", 20, false,
                    new ItemChanceData("PistolBullets", 30, true, null)),
                new ItemChanceData("Rifle", 5, false,
                    new ItemChanceData("RifleBullets", 10, true, null)),
                new ItemChanceData("RifleBullets", 10, true, null)
            });
            // Desk Drawer - Only find Bullets, Keys, Vaccines
            ItemChanceDB.Add("Container_DeskDrawer", new ItemChanceData[] 
            {
                new ItemChanceData("PistolBullets", 30, true, null),
                new ItemChanceData("MachineGunBullets", 20, true, null),
                new ItemChanceData("RifleBullets", 10, true, null),
                new ItemChanceData("Zone_A_Key", 25, false,
                    new ItemChanceData("PistolBullets", 30, true, null)),
                new ItemChanceData("Vaccine1", 10, true, null),
                new ItemChanceData("Vaccine2", 5, true, null)
            });
            ///////////////JACKSON END
        }
        if (GameManager.CharacterSelected == Enums.Character.Ryley)
        {
            ItemChanceDB.Add("Enemy_Tiger", new ItemChanceData[] 
            {
                new ItemChanceData("Reminder", 40, false, 
                    new ItemChanceData("Knife", 30, true, null)), // 40% Chance there's a pistol on a Tiger Enemy
                new ItemChanceData("Knife", 30, true, null),
                new ItemChanceData("Vaccine1",15, true, null),
                new ItemChanceData("Vaccine2",15, true, null)
            });
            // Gecko
            ItemChanceDB.Add("Enemy_Gecko", new ItemChanceData[] 
            {
                new ItemChanceData("MetalPipe", 15, false, 
                    new ItemChanceData("Knife", 20, true, null)),
                new ItemChanceData("Reminder", 40, false,
                    new ItemChanceData("Knife", 20, true, null)),
                new ItemChanceData("Knife",20, true, null),
                new ItemChanceData("Vaccine1",20, true, null),
                new ItemChanceData("Vaccine2",5, true, null)
            });
            // Lizard
            ItemChanceDB.Add("Enemy_Lizard", new ItemChanceData[] 
            {
                new ItemChanceData("Knife", 5, false,
                    new ItemChanceData("Vaccine1", 30, true, null)),
                new ItemChanceData("Reminder", 25, false, 
                    new ItemChanceData("Vaccine2", 20, true, null)),
                new ItemChanceData("MetalPipe", 10, true, null),
                new ItemChanceData("Vaccine1",30, true, null),
                new ItemChanceData("Vaccine2",20, true, null)
            });
            // Medical Kit - Only find vaccines
            ItemChanceDB.Add("Container_MedicalKit", new ItemChanceData[] 
            {
                new ItemChanceData("Vaccine1",65, false, 
                    new ItemChanceData("Vaccine2", 35, true, null)),
                new ItemChanceData("Vaccine2",35, true, null)
            });

            // Locker - Only find weapons & Bullets 
            ItemChanceDB.Add("Container_Locker", new ItemChanceData[] 
            {
                new ItemChanceData("MetalPipe", 20, false,
                    new ItemChanceData("Knife", 30, true, null)),
                new ItemChanceData("Knife", 30, true, null),
                new ItemChanceData("Reminder", 15, false, 
                    new ItemChanceData("Knife", 30, true, null))
            });
            // Desk Drawer - Only find Bullets, Keys, Vaccines
            ItemChanceDB.Add("Container_DeskDrawer", new ItemChanceData[] 
            {
                new ItemChanceData("Zone_A_Key", 25, false,
                    new ItemChanceData("Knife", 30, true, null)),
                new ItemChanceData("Vaccine1", 10, true, null),
                new ItemChanceData("Vaccine2", 5, true, null)
            });
            ////////RYLEY END
        }
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
    public string FindItemInLootableObject(string LootableObjectName, List<string> CurrentItemsInLoot)  // Returns ONE item based on chance
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
                    if (CurrentItemsInLoot.Count == 0) // No chance for duplicates
                    {
                        return ItemChances[i].GetItemName();
                    }
                    else if(CurrentItemsInLoot.Count > 0)
                    {
                        // If duplicates are not allowed for this item
                        if ((ItemChances[i].DuplicatesAllowed() == false)) 
                        {
                            // Check if there is a duplicate
                            foreach (string Loot in CurrentItemsInLoot)
                            {
                                if (Loot == ItemChances[i].GetItemName())
                                {
                                    // Duplicate found - return the item attached as ReturnInstead
                                    return ItemChances[i].GetReturnInsteadData().GetItemName();
                                }
                            }
                            // No duplicates found - Can return this
                            return ItemChances[i].GetItemName();
                        }
                        else // Duplicates of this item allowed - can return this
                        {
                            return ItemChances[i].GetItemName();
                        }
                    }
                }
            }
        }
        return ItemToReturn;
    }
}