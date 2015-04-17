using UnityEngine;
using System.Collections;

public class ItemChanceData
{
    // What are the chances it will appear on the associated lootableObject?
    private float LootChance;

    // The item itself
    private string ItemName;

    // Whether multiple instances of this item can be found
    //private bool CanBeDuplicated;
    public ItemChanceData(string ItemName, float LootChance) //bool CanBeDuplicated functionality done elsewhere
    {
        this.ItemName = ItemName; 
        this.LootChance = LootChance; 
        //this.CanBeDuplicated = CanBeDuplicated; 
    }
    public void SetLootChance(float Chance)
    {
        LootChance = Chance;
    }
    public float GetLootChance()
    {
        return LootChance;
    }
    public void SetItemID(string name)
    {
        ItemName = name;
    }
    public string GetItemName()
    {
        return ItemName;
    }
    /*public void SetCanHaveDuplicates(bool Duplicates)
    {
        CanBeDuplicated = Duplicates;
    }
    public bool CanLootBeDuplicated()
    {
        return CanBeDuplicated;
    }*/
}

