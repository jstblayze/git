// Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public enum ItemType
    {
        Pistol,
        MachineGun,
        Rifle,
        PistolBullets,
        MachineGunBullets,
        RifleBullets,
        Vaccine1,
        Vaccine2,
        Zone_A_Key
    }
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
        ItemType ItemType = (ItemType)System.Enum.Parse(typeof(ItemType), LootName);
        switch(ItemType)
        {
            default:
                Debug.Log("Something has been");
                break;
            case ItemType.Pistol:
                LootImage.sprite = Pistol;
                break;
            case ItemType.MachineGun:
                LootImage.sprite = MachineGun;
                break;
            case ItemType.Rifle:
                LootImage.sprite = Rifle;
                break;
            case ItemType.PistolBullets:
                LootImage.sprite = PistolBullets;
                break;
            case ItemType.MachineGunBullets:
                LootImage.sprite = MachineGunBullets;
                break;
            case ItemType.RifleBullets:
                LootImage.sprite = RifleBullets;
                break;
            case ItemType.Vaccine1:
                LootImage.sprite = Vaccine1;
                break;
            case ItemType.Vaccine2:
                LootImage.sprite = Vaccine2;
                break;
            case ItemType.Zone_A_Key:
                LootImage.sprite = Zone_A_Key;
                break;
        }
    }
	void Start () 
    {
        //LootText.text = "BLAHADasljdhflaksjdf";
        /*Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform T in ts)
        {
            Debug.Log(T.name);
        }*/
	}
	void Update () 
    {
	}
}
