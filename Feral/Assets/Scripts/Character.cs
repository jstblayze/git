// Author: Amina Khalique
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Character : MonoBehaviour
{
    public Text Name;
    public Text Health;
    public Text WeaponEquipped;
    public Text Infection;

    private string CharacterName;
    private float CharacterHealth;
    private float CharacterInfection;
    private Enums.Weapon CurrentEquippedWeapon;
    private Enums.Character CurrentCharacter;
    public void Start()
    {
        //CurrentCharacter = GameManager.CharacterSelected; // Bring back later
        CurrentCharacter = GameManager.CharacterSelected;
        Debug.Log("Character.cs: " + CurrentCharacter.ToString());
        //CurrentCharacter = Enums.Character.Ryley;
        // Set Character Prerequisites here
        switch (CurrentCharacter)
        {
            default:
                Debug.Log("Current Character not found!");
                break;
            case Enums.Character.Jackson:
                Debug.Log("Jackson Picked");
                CharacterName = "Jackson";
                CurrentEquippedWeapon = Enums.Weapon.Pistol;
                CharacterHealth = 100.0f;
                CharacterInfection = -1.0f;
                break;
            case Enums.Character.Ryley:
                Debug.Log("Ryley Picked");
                CharacterName = "Ryley";
                CurrentEquippedWeapon = Enums.Weapon.Claws;
                CharacterHealth = 100.0f;
                CharacterInfection = 0.0f;
                break;
            
        }
        Name.text = CharacterName;
        /*CharacterName = "Ryley";
        CurrentEquippedWeapon = Enums.Weapon.Claws;
        CharacterHealth = 100.0f;
        CharacterInfection = 0.0f;
        CharacterText.text = CharacterName;
        LoadModel();*/
    }
    public void Update()
    {
        Infection.text = (CharacterInfection >= 0.0f) ? "Infection : " + CharacterInfection : "Infection : Immune";
        Health.text = "Health : " + CharacterHealth;
        WeaponEquipped.text = "Weapon : " + CurrentEquippedWeapon.ToString();
    }
    public void LoadModel()
    {
        //>>>! Matthew Whitely or >>>! Agbolade Blaize
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
