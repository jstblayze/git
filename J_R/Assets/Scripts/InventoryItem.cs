// Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryItem : MonoBehaviour
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
    public Text LootText;
    public Image LootImage;
    private string LootName;

    public void SetLootName(string Name)
    {
        LootName = Name;
        LootText.text = LootName;
        SetLootImage();
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
        }
    }
    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Pointer Click is being activated!!!");
        switch (data.button)
        {
            case PointerEventData.InputButton.Left:
                Debug.Log("Left Clicked");
                break;
            case PointerEventData.InputButton.Right:
                Debug.Log("Right Clicked");
                break;
            case PointerEventData.InputButton.Middle:
                break;
        }
    }
}
