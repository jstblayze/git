// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class ItemChanceData
{
    private float LootChance;
    private string ItemName;
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
}

