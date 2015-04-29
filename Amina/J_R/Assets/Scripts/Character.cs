// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class Character : MonoBehaviour
{
    private string CharacterName;
    private float CharacterHealth;
    private float CharacterInfection;
    private Enums.Weapon CurrentEquippedWeapon;
    private Enums.Character CurrentCharacter;
   
    public void Start()
    {
        this.CharacterName = "Ryley"; // Set to default Ryley
        CurrentCharacter = (Enums.Character)System.Enum.Parse(typeof(Enums.Character), CharacterName);
        // Set Character Prerequisites here
        switch (CurrentCharacter)
        {
            case Enums.Character.Jackson:
                CurrentEquippedWeapon = Enums.Weapon.Pistol;
                CharacterHealth = 100.0f;
                CharacterInfection = -1.0f;
                Debug.Log("Jackson Character");
                break;
            case Enums.Character.Ryley:
                CurrentEquippedWeapon = Enums.Weapon.Claws;
                CharacterHealth = 100.0f;
                CharacterInfection = 0.0f;
                Debug.Log("Ryley Character");
                break;
        }
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
