﻿// Author: Amina Khalique
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
    private Dictionary<string, InventoryItemData[]> Inventory = new Dictionary<string, InventoryItemData[]>();
    private InventoryItemData[] CurrentlyLookAt;

    public Text Health;
    public Text Infection;
    public RectTransform InventoryWindowItems;
    
    void Awake()
    {
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
        Inventory.Add("Maps", new InventoryItemData[] 
        {
            GameManager.LootManager.GetItemData("Zone1"),
            GameManager.LootManager.GetItemData("Zone2"),
            GameManager.LootManager.GetItemData("Zone3")
        });
    }
    void Start () 
    {
        No_Items.gameObject.SetActive(false);
        MapScreen.SetActive(false);
        //SelectInventoryCategory("Weapons");
        //Weapons.GetComponent<Button>().Select();
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
        foreach (KeyValuePair<string, InventoryItemData[]> pair in Inventory)
        {
            Debug.Log(pair.Key + " " + Category);
            if (pair.Key == Category)
            {
                Debug.Log("Match!");
                CurrentlyLookAt = pair.Value;
                if (CurrentlyLookAt != null && CurrentlyLookAt.Length > 0)
                {
                    foreach (InventoryItemData ICD in CurrentlyLookAt)
                    {
                        Debug.Log(ICD.ToString());
                    }
                }
                else
                {
                    Debug.Log("CurrentlyLookAt is null");
                }
                break;
            }
        }
        if (CurrentlyLookAt != null && CurrentlyLookAt.Length != 0)
        {
            for (int i = 0; i < CurrentlyLookAt.Length; i++)
            {
                InventoryItem InventoryItem = PreFab_InventoryItemPanel.GetComponent<InventoryItem>();
                InventoryItem.SetLootName(CurrentlyLookAt[i].GetItemName());
                InventoryItem.SetPickupOrDrop(Enums.Item.Drop);

                GameObject IIP = (GameObject)Instantiate(PreFab_InventoryItemPanel, transform.position, Quaternion.identity);
                IIP.transform.SetParent(InventoryWindowItems.transform);

                if(i == CurrentlyLookAt.Length -1)
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
        for(int i = 0; i < CurrentlyLookAt.Length; i++)
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
        InventoryItemData[] Data = Inventory[Category];
        if(Data != null)
        {
            InventoryItemData[] Temp = new InventoryItemData[Data.Length + 1];
            // Copy over all values from Data to Temp
            for (int i = 0; i < Temp.Length; i++)
            {
                if (i != Temp.Length - 1)
                {
                    Temp[i] = Data[i];
                }
                else
                {
                    Temp[i] = GameManager.LootManager.GetItemData(ItemName);
                    Debug.Log("Temp[i]" + Temp[i].ToString());
                }
            }
            Inventory[Category] = Temp;
        }
    }
    public void RemoveItemFromInventory(string ItemName, string Category)
    {
        InventoryItemData[] Data = Inventory[Category];
        if (Data != null)
        {
            InventoryItemData[] Temp = new InventoryItemData[Data.Length - 1];
            // Copy over all values from Data to Temp
            for (int i = 0; i < Data.Length; i++)
            {
                if (!(Data[i].GetItemName() == ItemName))
                {
                    Temp[i] = Data[i];
                }
            }
            Inventory[Category] = Temp;
            DisplayInventoryCategory(Category);
        }
    }
}
