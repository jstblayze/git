// Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryItem : MonoBehaviour // Multiple inheritance not supported
{ 
    public Sprite Pistol;
    public Sprite MachineGun;
    public Sprite Rifle;
    public Sprite PistolBullets;
    public Sprite MachineGunBullets;
    public Sprite RifleBullets;
    public Sprite Vaccine1;
    public Sprite Vaccine2;
    public Sprite Zone_A_Key;
    public Sprite Zone1;
    public Sprite Zone2;
    public Sprite Zone3;
    public Sprite Pickup;
    public Sprite Drop;

    public Text LootText;
    public Image LootImage;
    public Image PickUpOrDrop;
    
    private string LootName;
    private string Category;

    public void SetLootName(string Name)
    {
        LootName = Name;
        LootText.text = LootName;
        SetLootImage();
    }
    public string GetCategory()
    {
        return Category;
    }
    public string GetLootName()
    {
        return LootName; 
    }
    public void SetPickupOrDrop(Enums.Item PickDrop)
    {
        switch(PickDrop)
        {
            case Enums.Item.Pickup:
                PickUpOrDrop.sprite = Pickup;
                break;
            case Enums.Item.Drop:
                PickUpOrDrop.sprite = Drop;
                break;
        }
    }
    public void SetLootImage()
    {
        // Convert string to enum
        Enums.Item Item = (Enums.Item)System.Enum.Parse(typeof(Enums.Item), LootName);
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
                // Maps
            case Enums.Item.Zone1:
                LootImage.sprite = Zone1;
                break;
            case Enums.Item.Zone2:
                LootImage.sprite = Zone2;
                break;
            case Enums.Item.Zone3:
                LootImage.sprite = Zone3;
                break;
        }
    }
    public void OnMouseDown()  
    {
        // Check which screen is active
        switch(GameManager.CurrentlyActiveUI)
        {
            case Enums.ActiveUI.InventoryScreen:
                Debug.Log("OnMouseDown:" + LootName + ".");
                //GameManager.InventoryScreen.SelectInventoryItem(LootName, LootImage);
                GameManager.InventoryScreen.SelectInventoryItem(LootText.text, LootImage);
                break;
            case Enums.ActiveUI.LootScreen:
                break;
        }
    }
    public override string ToString()
    {
        return "InventoryItem: " + LootName;
    }
    public void PickupDropImagePressed(Text ItemName)
    {
        Debug.Log("PickupDropImagePressed! with: " + ItemName.text);
        if (ItemName.text.Contains("Vaccine") || ItemName.text.Contains("Key"))
        {
            Category = "Items";
        }
        else if (ItemName.text.Contains("Zone"))
        {
            Category = "Maps";
        }
        else Category = "Weapons";
        if(PickUpOrDrop.sprite.name.Contains("Drop"))
        {
            Debug.Log("Attempting to Drop Item");
            GameManager.InventoryScreen.RemoveItemFromInventory(ItemName.text, Category);
        }
        else if(PickUpOrDrop.sprite.name.Contains("Checkmark")) 
        {
            Debug.Log("Attempting to Pick up Item with Category:" + Category);
            GameManager.InventoryScreen.AddItemToInventory(ItemName.text, Category);
            // Destroy from loot screen & loot items
            Destroy(gameObject);
            GameManager.ObjectInLootRange.RemoveFromLoot(ItemName.text);
        }
    }
}
