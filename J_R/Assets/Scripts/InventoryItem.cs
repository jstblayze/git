﻿// Author: Amina Khalique
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
    public Text LootText;
    public Image LootImage;
    
    private string LootName;

    public void SetLootName(string Name)
    {
        LootName = Name;
        LootText.text = LootName;
        SetLootImage();
    }
    public string GetLootName()
    {
        return LootName; 
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
}
