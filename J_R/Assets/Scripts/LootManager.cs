using System.Collections;
using System.Collections.Generic;
// Author : Amina Khalique >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DISCUSS PERCENTAGES WITH LEAD DESIGNER - RYAN G
using UnityEngine;
/* Class purpose:
   Manager to keep track of Databases holding info on loot chance of certain items in certain areas 
 */
public class LootManager : MonoBehaviour
{
    List<LootableObject> OpenedLootableObjects = new List<LootableObject>();
    private Dictionary<string, int[]> ItemCountRandomizerDB = new Dictionary<string,int[]>();
    private Dictionary<string, ItemChanceData[]> ItemChanceDB = new Dictionary<string, ItemChanceData[]>();
    
    public void AddToOpenedLootList(LootableObject LootableObject)
    {
        OpenedLootableObjects.Add(LootableObject);
    }
    public void ResetAllOpenedLoot()
    {
        foreach(LootableObject LootObject in OpenedLootableObjects)
        {
            LootObject.SetLooted(false);
            LootObject.ResetItems();
        }
        OpenedLootableObjects = new List<LootableObject>();
    }
    void Start()
    {
        //Create Randomizer Database for how many items can be found in a container or on an enemy
        //Position Corresponds to item count 
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
            new ItemChanceData("Vaccine1.0",15),
            new ItemChanceData("Vaccine2.0",15)
        });
        // Gecko
        ItemChanceDB.Add("Enemy_Gecko", new ItemChanceData[] 
        {
            new ItemChanceData("Pistol", 15),
            new ItemChanceData("MachineGun", 40),
            new ItemChanceData("MachineGunBullets",20),
            new ItemChanceData("Vaccine1.0",20),
            new ItemChanceData("Vaccine2.0",5)
        }); 
        // Lizard
        ItemChanceDB.Add("Enemy_Lizard", new ItemChanceData[] 
        {
            new ItemChanceData("Pistol", 5),
            new ItemChanceData("Rifle", 25),
            new ItemChanceData("RifleBullets",10),
            new ItemChanceData("Vaccine1.0",30),
            new ItemChanceData("Vaccine2.0",20)
        }); 
        // Medical Kit - Only find vaccines
        ItemChanceDB.Add("Container_MedicalKit", new ItemChanceData[] 
        {
            new ItemChanceData("Vaccine1.0",65),
            new ItemChanceData("Vaccine2.0",35)
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
            new ItemChanceData("Vaccine1.0", 10),
            new ItemChanceData("Vaccine2.0", 5)
        });
    }
    /// <summary>
    /// Purpose: Return number of items found in Lootable Object.
    /// When a LootableObject is opened, how many items will you find? 
    /// How many items you will find is dependent on the ItemCountRandomizerDB
    /// </summary>
    /// <param name="LootableObjectName"></param>
    /// <returns></returns>
    /// 
    public int ItemsInLootableObject(string LootableObjectName) 
    {
        // Need to double check functionality with a better test - Luki >>>>>>>>>>>
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
    /// <summary>
    /// Purpose: Returns the name of an item found on the Lootable Object
    /// This is based on "Loot Chance". Refer to to ItemChanceDB.
    /// Eg: The chances of finding a pistol on a TigerEnemy is 40%
    /// </summary>
    /// <param name="LootableObjectName"></param>
    /// <returns></returns>
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
                Range += (int)ItemChances[i].GetLootChance(); // Totals up the loot chance
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