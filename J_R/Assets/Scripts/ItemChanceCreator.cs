using UnityEngine;
using System.Collections;

public class ItemChanceCreator
{
    // This should match with a container ID OR Enemy ID (AKA anything lootable) & describes where the item will be found
    private string LootableObjectName;

    // What are the chances it will appear here?
    private float LootChance;

    // The item itself
    private string ItemName;

    // Whether multiple instances of this item can be found
    private bool CanBeDuplicated;

    // Constructor for this class
    public ItemChanceCreator(string LootableObjectName, string ItemName, float LootChance, bool CanBeDuplicated)
    {
        this.LootableObjectName = LootableObjectName;
        this.ItemName = ItemName; 
        this.LootChance = LootChance; 
        this.CanBeDuplicated = CanBeDuplicated; 
    }
	void Start () 
    {
	
	}
	void Update () 
    {
	
	}
    public void SetLootableObjectID(string name)
    {
        LootableObjectName = name;
    }
    public string GetLootableObjectName()
    {
        return LootableObjectName;
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
    public void SetCanHaveDuplicates(bool Duplicates)
    {
        CanBeDuplicated = Duplicates;
    }
    public bool CanLootBeDuplicated()
    {
        return CanBeDuplicated;
    }

}

