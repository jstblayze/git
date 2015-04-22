// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class Character : MonoBehaviour
{
    private string CharacterName;
    private float CharacterHealth = 100f;
    private float CharacterInfection = 50f;
    private int CurrentEquippedWeapon; // will be an enum - 0 is default
    private Inventory Inventory;
    Character(string CharacterName, float CharacterHealth, float Characternfection, int CurrentEquippedWeapon, Inventory Inventory)
    {
        this.Inventory = new Inventory();
        this.CharacterName = CharacterName;
        if(CharacterName == "Jackson")
        {
        }
        else
        {
        }
        CurrentEquippedWeapon = 0; // Default for the character
    }
}
