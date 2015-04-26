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
        Map
    }
    private Dictionary<string, InventoryItemData[]> Inventory = new Dictionary<string, InventoryItemData[]>();
    private InventoryItemData[] CurrentlyLookAt;

    public Text Health;
    public Text Infection;
    public RectTransform InventoryWindowItems;
    void Start () 
    {
        No_Items.gameObject.SetActive(false);
        MapScreen.SetActive(false);

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
        Inventory.Add("Map", new InventoryItemData[] 
        {
            GameManager.LootManager.GetItemData("Zone1"),
            GameManager.LootManager.GetItemData("Zone2"),
            GameManager.LootManager.GetItemData("Zone3")
        });

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
            case InventoryCategory.Map:
                ShowArrow(Map);
                HideArrow(Weapons);
                HideArrow(Items);
                DisplayInventoryCategory(Category);
                break;
        }
    }
    public void ShowArrow(GameObject Category)
    {
        Debug.Log("Show Arrow: " + Category.name);
        foreach(Transform Image in Category.GetComponentInChildren<Transform>())
        {
            Debug.Log(Image.gameObject.name);
            if(Image.gameObject.name.Contains("CategoryArrow"))
            {
                Image.gameObject.GetComponent<Image>().sprite = Arrow;
                break;
            }
        }
    }
    public void HideArrow(GameObject Category)
    {
        Debug.Log("Hide Arrow: " + Category.name);
        foreach (Transform Image in Category.GetComponentInChildren<Transform>())
        {
            Debug.Log(Image.gameObject.name);
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
            if (pair.Key == Category)
            {
                CurrentlyLookAt = pair.Value;
                break;
            }
        }
        if (CurrentlyLookAt != null && CurrentlyLookAt.Length != 0)
        {
            for (int i = 0; i < CurrentlyLookAt.Length; i++)
            {
                InventoryItem InventoryItem = PreFab_InventoryItemPanel.GetComponent<InventoryItem>();
                InventoryItem.SetLootName(CurrentlyLookAt[i].GetItemName());

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
}
