using System.Collections;
using System.Collections.Generic;
// Author : Amina Khalique
using UnityEngine;
/* Class purpose:
   Creates Databases holding info on loot chance of certain items in certain areas 
   Contains methods for randomization */
public class LootManager : MonoBehaviour
{
    // Holds percetages of a lootable item having 0, 1, 2, 3, 4, 5 items on it during loot
    private Dictionary<string, int[]> ItemCountRandomizerDB = new Dictionary<string,int[]>();
    private List<ItemChanceCreator> ItemChanceDB = new List<ItemChanceCreator>();
    void Start()
    {
        /* Create Randomizer Database for how many items can be found in a container or on an enemy
           What are the chances you'll find between 0 to 5 items on a "lootable" item?
           LootableItemName, 0Items, 1Items, 2Items, 3Items, 4Items */
        ItemCountRandomizerDB.Add("Enemy_Tiger", new int[] { 0, 25, 50, 20, 5 });
        ItemCountRandomizerDB.Add("Enemy_Lizard", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Enemy_Gecko", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Container_Locker", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Container_DeskDrawer", new int[] { 20, 20, 20, 20, 20 });
        ItemCountRandomizerDB.Add("Container_MedicalKit", new int[] { 20, 20, 20, 20, 20 });

        // Create Item Chance Database
        // ItemChanceCreator(int LootableObjectName, int ItemID, int LootChance, bool CanBeDuplicated)

        //LITemName, ItemName, LootChance, Duplicates?                  
        // Tiger
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Tiger", "Pistol", 40, false)); // Means there's a 40% chance a Tiger enemy has a Pistol on him
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Tiger", "PistolBullets", 30, true));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Tiger", "Vaccine1.0", 15, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Tiger", "Vaccine2.0", 15, false));

        // Gecko
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Gecko", "Pistol", 15, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Gecko", "MachineGun", 40, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Gecko", "MachineGunBullets", 20, true));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Gecko", "Vaccine1.0", 20, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Gecko", "Vaccine2.0", 5, false));

        // Lizard
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Lizard", "Pistol", 5, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Lizard", "Rifle", 25, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Lizard", "RifleBullets", 10, true));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Lizard", "Vaccine1.0", 30, false));
        ItemChanceDB.Add(new ItemChanceCreator("Enemy_Lizard", "Vaccine2.0", 20, false));

        // Medical Kit - Only find vaccines
        ItemChanceDB.Add(new ItemChanceCreator("Container_MedicalKit", "Vaccine1.0", 65, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_MedicalKit", "Vaccine2.0", 35, true));

        // Locker - Only find weapons & Bullets - Add Melee after talking with Ryan G >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "Pistol", 20, false));
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "PistolBullets", 30, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "MachineGun", 15, false));
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "MachineGunBullets", 20, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "Rifle", 5, false));
        ItemChanceDB.Add(new ItemChanceCreator("Container_Locker", "RifleBullets", 10, true));

        // Desk Drawer - Only find Bullets, Keys, Vaccines
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "PistolBullets", 30, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "RifleBullets", 10, false));
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "MachineGunBullets", 20, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "Zone_A_Key", 25, false));
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "Vaccine1.0", 10, true));
        ItemChanceDB.Add(new ItemChanceCreator("Container_DeskDrawer", "Vaccine2.0", 5, false));
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>
    public int ItemsInLootableObject(string LootableObjectName) 
    {
        int[] RandomItemCount;
        ItemCountRandomizerDB.TryGetValue(LootableObjectName, out RandomItemCount); //gotten the appropriate array
        // How do I create a randomizer?
        return 2; 
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>
    public string FindItemInLootableObject(string LootableObjectName) 
    {
        // Find a way to get an item name based on the loot chance in the ItemChanceDB table
        return "Pistol";
    }
    void Update()
    {

    }
}