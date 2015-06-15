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
    public GameObject PreFab_InventoryItemPanel;

    public GameObject Weapons;
    public GameObject Items;
    public GameObject Map;

    public Sprite None;
    public Sprite Arrow;

    public GameObject MapScreen;
    public Image MapImage;
    public Image MapClose;

    enum InventoryCategory
    {
        Weapons,
        Items,
        Maps
    }
    //private Dictionary<string, InventoryItemData[]> Inventory = new Dictionary<string, InventoryItemData[]>();
    private Dictionary<string, List<InventoryItemData>> Inventory = new Dictionary<string, List<InventoryItemData>>();
    
    //private InventoryItemData[] CurrentlyLookAt;
    private List<InventoryItemData> CurrentlyLookAt;

    public Text Health;
    public Text Infection;
    public RectTransform InventoryWindowItems;
    
    void Awake()
    {
        List<InventoryItemData> Weapons = new List<InventoryItemData>();
        List<InventoryItemData> Items = new List<InventoryItemData>();
        List<InventoryItemData> Maps = new List<InventoryItemData>();

        //GameManager.CharacterSelected = Enums.Character.Ryley; // SET IT
        if(GameManager.CharacterSelected == Enums.Character.Jackson)
        {
            // Add to weapons
            Weapons.Add(GameManager.LootManager.GetItemData("Pistol"));
            Weapons.Add(GameManager.LootManager.GetItemData("Rifle"));
            Weapons.Add(GameManager.LootManager.GetItemData("MachineGun"));
            Weapons.Add(GameManager.LootManager.GetItemData("PistolBullets"));
            Inventory.Add("Weapons", Weapons);
        }
        if(GameManager.CharacterSelected == Enums.Character.Ryley)
        {
            // Add to weapons
            // For Zone 2:

            if(GameManager.LootManager == null)
            {
                Debug.Log("LootManager is null");
            }
            // For Zone 1:
            Weapons.Add(GameManager.LootManager.GetItemData("MetalPipe"));
            Weapons.Add(GameManager.LootManager.GetItemData("Reminder"));
            Weapons.Add(GameManager.LootManager.GetItemData("Knife"));
            Weapons.Add(GameManager.LootManager.GetItemData("Knife"));
            Inventory.Add("Weapons", Weapons);
        }

        /*Weapons.Add(GameManager.LootManager.GetItemData("MetalPipe"));
        Weapons.Add(GameManager.LootManager.GetItemData("Reminder"));
        Weapons.Add(GameManager.LootManager.GetItemData("Knife"));
        Inventory.Add("Weapons", Weapons);*/

        // Add to items
        Items.Add(GameManager.LootManager.GetItemData("Vaccine1"));
        Items.Add(GameManager.LootManager.GetItemData("Zone_A_Key"));
        Inventory.Add("Items", Items);

        // Add to maps
        Maps.Add(GameManager.LootManager.GetItemData("Zone1"));
        Maps.Add(GameManager.LootManager.GetItemData("Zone2"));
        Maps.Add(GameManager.LootManager.GetItemData("Zone3"));
        Inventory.Add("Maps", Maps);
    }
    void Start () 
    {
        No_Items.gameObject.SetActive(false);
        MapScreen.SetActive(false);
        gameObject.SetActive(false);
	}
    public void OnOpenInventoryScreen()
    {
        SelectInventoryCategory("Weapons");
        Weapons.GetComponent<Button>().Select();
    }
    public bool HasKey(string KeyRequired)
    {
        List<InventoryItemData> Items = null;
        Inventory.TryGetValue("Items", out Items);
        if(Items.Capacity >= 0)
        {
            foreach(InventoryItemData Item in Items)
            {
                if(Item.GetItemName() == KeyRequired)
                {
                    return true;
                }
            }
        }
        return false;
    }
	void Update ()
    {
        // Base Infection & Health on Character.cs class
        Health.text = "Health : " + ZoneManager.Character.GetCharacterHealth() + " %";
        if (ZoneManager.Character.GetCharacter() == Enums.Character.Jackson)
        {
            Infection.text = "Infection : Immune";
        }
        else
        {
            Infection.text = "Infection : " + ZoneManager.Character.GetCharacterInfection() + "%";
        }
	}
    public void SelectInventoryCategory(string Category) 
    {
        No_Items.gameObject.SetActive(false);
        CurrentlyLookAt = null;
        // Change String Category into Inventory Category using Enum.Parse System Method
        InventoryCategory InventoryCategory = (InventoryCategory)
            System.Enum.Parse(typeof(InventoryCategory), Category);
        switch(InventoryCategory)
        {
            case InventoryCategory.Weapons:
                ShowArrow(Weapons);
                HideArrow(Items);
                HideArrow(Map);
                DisplayInventoryCategory(Category);
                break;
            case InventoryCategory.Items:
                ShowArrow(Items);
                HideArrow(Weapons);
                HideArrow(Map);
                DisplayInventoryCategory(Category);
                break;
            case InventoryCategory.Maps:
                ShowArrow(Map);
                HideArrow(Weapons);
                HideArrow(Items);
                DisplayInventoryCategory(Category);
                break;
        }
    }
    public void ShowArrow(GameObject Category)
    {
        foreach(Transform Image in Category.GetComponentInChildren<Transform>())
        {
            if(Image.gameObject.name.Contains("CategoryArrow"))
            {
                Image.gameObject.GetComponent<Image>().sprite = Arrow;
                break;
            }
        }
    }
    public void HideArrow(GameObject Category)
    {
        foreach (Transform Image in Category.GetComponentInChildren<Transform>())
        {
            if (Image.gameObject.name.Contains("CategoryArrow"))
            {
                Image.gameObject.GetComponent<Image>().sprite = None;
                break;
            }
        }
    }
    public void DisplayInventoryCategory(string Category)
    {
        ClearInventoryItemsFromCategory();
        foreach (KeyValuePair<string, List<InventoryItemData>> pair in Inventory)
        {
            if (pair.Key == Category)
            {
                Debug.Log("DisplayInventoryCategory() + " + pair.Key + " matches " + Category);
                CurrentlyLookAt = pair.Value;
                Debug.Log("CurrentlyLookAt's count: " + CurrentlyLookAt.Count);
                break;
            }
        }
        if (CurrentlyLookAt != null && CurrentlyLookAt.Count != 0)
        {
            for (int i = 0; i < CurrentlyLookAt.Count; i++)
            {
                InventoryItem InventoryItem = PreFab_InventoryItemPanel.GetComponent<InventoryItem>();
                InventoryItem.SetLootName(CurrentlyLookAt[i].GetItemName());
                InventoryItem.SetPickupOrDrop(Enums.Item.Drop);

                GameObject IIP = (GameObject)Instantiate(PreFab_InventoryItemPanel, transform.position, Quaternion.identity);
                IIP.transform.SetParent(InventoryWindowItems.transform);

                if (i == 0)
                {
                    IIP.GetComponent<Button>().Select(); // This isn't working the first time
                    SelectInventoryItem(CurrentlyLookAt[i].GetItemName(), InventoryItem.LootImage);
                }
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
        InventoryStatsImage.sprite = InventoryImage.sprite;
        for(int i = 0; i < CurrentlyLookAt.Count; i++)
        {
            if(CurrentlyLookAt[i].GetItemName() == ItemName)
            {
                InventoryStatsDescription.text = CurrentlyLookAt[i].GetDescription();
                InventoryStatsStats.text = CurrentlyLookAt[i].GetStats();
                break;
            }
        }
    }
    public void MapImagePressed(GameObject Image)
    {
        MapScreen.SetActive(true);
        MapImage.sprite = Image.GetComponent<Image>().sprite;
    }
    public void CloseMapPressed()
    {
        MapScreen.SetActive(false);
    }
    public void AddItemToInventory(string ItemName, string Category)
    {
        Debug.Log("Add " + ItemName + " to : " + Category);

        List<InventoryItemData> Data = Inventory[Category];
        Data.Add(GameManager.LootManager.GetItemData(ItemName));
        Inventory[Category] = Data;
    }
    public void RemoveItemFromInventory(string ItemName, string Category)
    {
        List<InventoryItemData> Data = Inventory[Category];
        if (Data != null)
        {
            int IndexToRemove = -1;
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].GetItemName() == ItemName)
                {
                    IndexToRemove = i;
                    break;
                }
            }
            Data.RemoveAt(IndexToRemove);
            Inventory[Category] = Data;
            DisplayInventoryCategory(Category);
        }
    }
}
