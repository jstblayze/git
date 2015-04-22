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
            new InventoryItemData("Pistol","It's a gun you dumbass", "10 Pistol Bullets"),
            new InventoryItemData("Rifle", "Something I'd like to shoot you with right now", "20 Rifle Ammo"),
            new InventoryItemData("MachineGun", "Jesus can you stop waving that thing around?!", "Machine Gun Ammo")
        });
        Inventory.Add("Items", new InventoryItemData[]
        {
            new InventoryItemData("Vaccine1", "It cures your health/infection", "Costs 20HP to use if your Ryley and costs 500,000 to use if you're jackson LOL jk")
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
    public void SelectInventoryItem(string Position)
    {
        Debug.Log("Inventory Item Selected : " + Position);
        // Make sure selection changes happen here
        if(GameManager.InventoryScreenOpen && !GameManager.LootableScreenInventoryOpen)
        {
            DisplayInventoryItemStats();
            /*
             * Enums.Item Item = (Enums.Item)System.Enum.Parse(typeof(Enums.Item), LootName);
        switch(Item)
        {
            default:
                Debug.Log("InventoryItem.cs: Item Not Recognized");
                break;
            case Enums.Item.Pistol:
                LootImage.sprite = Pistol;
                break;
            case Enums.Item.MachineGun:
                LootImage.sprite = MachineGun;
                break;
            case Enums.Item.Rifle:
                LootImage.sprite = Rifle;
                break;
            case Enums.Item.PistolBullets:
                LootImage.sprite = PistolBullets;
                break;
            case Enums.Item.MachineGunBullets:
                LootImage.sprite = MachineGunBullets;
                break;
            case Enums.Item.RifleBullets:
                LootImage.sprite = RifleBullets;
                break;
            case Enums.Item.Vaccine1:
                LootImage.sprite = Vaccine1;
                break;
            case Enums.Item.Vaccine2:
                LootImage.sprite = Vaccine2;
                break;
            case Enums.Item.Zone_A_Key:
                LootImage.sprite = Zone_A_Key;
                break;
        }
             */
        }
    }
    public void DisplayInventoryItemStats()
    {
    }
}
