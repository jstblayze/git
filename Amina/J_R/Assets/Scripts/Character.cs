// Author: Amina Khalique
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Character : MonoBehaviour
{
    public Text CharacterText; 
    private string CharacterName;
    private float CharacterHealth;
    private float CharacterInfection;
    private Enums.Weapon CurrentEquippedWeapon;
    private Enums.Character CurrentCharacter;
   
    public void Start()
    {
        CurrentCharacter = GameManager.CharacterSelected;
        // Set Character Prerequisites here
        switch (CurrentCharacter)
        {
            case Enums.Character.Jackson:
                CharacterName = "Jackson";
                CurrentEquippedWeapon = Enums.Weapon.Pistol;
                CharacterHealth = 100.0f;
                CharacterInfection = -1.0f;
                break;
            case Enums.Character.Ryley:
                CharacterName = "Ryley";
                CurrentEquippedWeapon = Enums.Weapon.Claws;
                CharacterHealth = 100.0f;
                CharacterInfection = 0.0f;
                break;
        }
        CharacterText.text = CharacterName;
        LoadModel();
    }
    public void LoadModel()
    {
        //>>>! Matthew Wayne or >>>! Agbolade Blaize
        // Load either Ryley or Jackson with the following:
        // Correct animation blend tree
        // Correct Model
        // In the correct position in the level
        switch (CurrentCharacter)
        {
            case Enums.Character.Jackson:
                //
                break;
            case Enums.Character.Ryley:
               //
                break;
        }
    }
    public float GetCharacterHealth()
    {
        return CharacterHealth;
    }
    public float GetCharacterInfection()
    {
        return CharacterInfection;
    }
    public Enums.Character GetCharacter()
    {
        return CurrentCharacter;
    }
}
