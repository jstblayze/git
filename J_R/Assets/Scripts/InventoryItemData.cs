using UnityEngine;
using System.Collections;

public class InventoryItemData
{
    private string ItemName;
    private string Description;
    private string Stats;
    public InventoryItemData(string ItemName, string Description, string Stats)
    {
        this.ItemName = ItemName;
        this.Description = Description;
        this.Stats = Stats;
    }
    public string GetItemName()
    {
        return ItemName;
    }
    public string GetStats()
    {
        return Stats;
    }
    public string GetDescription()
    {
        return Description;
    }
    public override string ToString()
    {
        return "ItemName:" + ItemName + "\n" +
                "Description:" + Description + "\n" +
                "Stats:" + Stats + "\n";
    }
}
