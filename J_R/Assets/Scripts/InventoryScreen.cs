// Author: Amina Khalique
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class InventoryScreen : MonoBehaviour 
{
    public Image InventoryStatsImage;
    public Text InventoryStatsDescription;
    public Text InventoryStatsStats;

    public Text No_Items;
    public GameObject PreFab_InventoryItem;
    enum InventoryCategory
    {
        Weapons,
        Items,
        Map
    }
    private Dictionary<string, InventoryItemData[]> Inventory = new Dictionary<string, InventoryItemData[]>();
    private InventoryItemData[] CurrentlyLookAt;

    public Text Health;
    public Text Infection;
    public RectTransform InventoryWindowItems;

    private int CurrentSelectedCategory;
    private int CurrentSelectedRowNumber;
    private int CurrentEquippedItem;
    void Start () 
    {
        No_Items.gameObject.SetActive(false);
        CurrentSelectedCategory = 1; // Weapon
        CurrentSelectedRowNumber = 1; // First item in the category

        Inventory.Add("Weapons", new InventoryItemData[] 
        {
            GameManager.LootManager.GetItemData("Pistol"),
            GameManager.LootManager.GetItemData("Rifle"),
            GameManager.LootManager.GetItemData("MachineGun")
        });
        Inventory.Add("Items", new InventoryItemData[]
        {
            GameManager.LootManager.GetItemData("Vaccine1")
        });
	}
	void Update ()
    {
        // Base Infection & Health on Character.cs class
        Health.text = "Health : " + GameManager.Character.GetCharacterHealth() + " %";
        if(GameManager.Character.GetCharacter() == Enums.Character.Jackson)
        {
            Infection.text = "Infection : Immune";
        }
        else
        {
            Infection.text = "Infection : " + GameManager.Character.GetCharacterInfection() + "%";
        }
	}
    public void SelectInventoryCategory(string Category) 
    {
        No_Items.gameObject.SetActive(false);
        CurrentlyLookAt = null;
        InventoryCategory InventoryCategory = (InventoryCategory)
            System.Enum.Parse(typeof(InventoryCategory), Category);
        switch(InventoryCategory)
        {
            case InventoryCategory.Weapons:
                DisplayInventoryCategory(Category);
                break;
            case InventoryCategory.Items:
                DisplayInventoryCategory(Category);
                break;
            case InventoryCategory.Map:
                // Do Something Different
                break;
        }
    }
    public void DisplayInventoryCategory(string Category)
    {
        ClearInventoryItemsFromCategory();
        // When you select a new category you should clear it
        foreach (KeyValuePair<string, InventoryItemData[]> pair in Inventory)
        {
            if (pair.Key == Category)
            {
                CurrentlyLookAt = pair.Value;
                break;
            }
        }
        if (CurrentlyLookAt.Length != 0)
        {
            for (int i = 0; i < CurrentlyLookAt.Length; i++)
            {
                InventoryItem InventoryItem = PreFab_InventoryItem.GetComponent<InventoryItem>();
                InventoryItem.SetLootName(CurrentlyLookAt[i].GetItemName());

                GameObject IItem = (GameObject)Instantiate(PreFab_InventoryItem, new Vector3(5.5f, 5.5f), Quaternion.identity);
                IItem.transform.SetParent(InventoryWindowItems.transform);
            }
        }
        else // clear it to be safe
        {
            ClearInventoryItemsFromCategory();
            No_Items.gameObject.SetActive(true);
        }
    }
    public void ClearInventoryItemsFromCategory()
    {
        List<GameObject> Children = new List<GameObject>();
        foreach (Transform Child in (InventoryWindowItems.GetComponentInChildren<Transform>()))
        {
            Children.Add(Child.gameObject);
        }
        foreach (GameObject Child in Children)
        {
            Destroy(Child);
        }
    }
    public void SelectInventoryItem(string ItemName, Image InventoryImage)
    {
        Debug.Log("SelectedInventoryItem:" + ItemName + ".");
        InventoryStatsImage.sprite = InventoryImage.sprite;

        // Get the description and the text based on the name
        for(int i = 0; i < CurrentlyLookAt.Length; i++)
        {
            Debug.Log("Trying to match:" + CurrentlyLookAt[i].GetItemName() + " with " + ItemName + ".");
            if(CurrentlyLookAt[i].GetItemName() == ItemName)
            {
                InventoryStatsDescription.text = CurrentlyLookAt[i].GetDescription();
                InventoryStatsStats.text = CurrentlyLookAt[i].GetStats();
                break;
            }
        }
    }
}
