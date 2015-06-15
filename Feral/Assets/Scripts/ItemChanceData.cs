// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class ItemChanceData
{
    private float LootChance;
    private string ItemName;
    private bool CanBeDuplicated;
    private ItemChanceData ReturnInstead;
    public ItemChanceData(string ItemName, float LootChance, bool CanBeDuplicated, ItemChanceData ReturnInstead) //bool CanBeDuplicated functionality done elsewhere
    {
        this.ItemName = ItemName; 
        this.LootChance = LootChance; 
        this.CanBeDuplicated = CanBeDuplicated;
        this.ReturnInstead = ReturnInstead;
    }
    public ItemChanceData GetReturnInsteadData()
    {
        return ReturnInstead;
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
    public bool DuplicatesAllowed()
    {
        return CanBeDuplicated;
    }
}

