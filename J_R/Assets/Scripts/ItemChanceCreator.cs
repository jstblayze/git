using UnityEngine;
using System.Collections;

public class ItemChanceCreator : MonoBehaviour 
{
    private int LootableObectID; // This should match with a container ID OR Enemy ID
    private int LootChance;
    private int ItemID;
    private bool CanBeDuplicated;

    // Constructor for this class
    public ItemChanceCreator(int LootableObjectID, int ItemID, int LootChance, bool CanBeDuplicated)
    {
        this.LootableObectID = LootableObjectID;
        this.ItemID = ItemID;
        this.LootChance = LootChance;
        this.CanBeDuplicated = CanBeDuplicated;
    }
	void Start () 
    {
	
	}
	void Update () 
    {
	
	}
    public void SetLootableObjectID(int ID)
    {
        LootableObectID = ID;
    }
    public int GetLootableObjectID()
    {
        return LootableObectID;
    }
    public void SetLootChance(int Chance)
    {
        LootChance = Chance;
    }
    public int GetLootChance()
    {
        return LootChance;
    }
    public void SetItemID(int ID)
    {
        ItemID = ID;
    }
    public int GetItemID()
    {
        return ItemID;
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

