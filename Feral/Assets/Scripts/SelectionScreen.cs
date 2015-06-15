// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class SelectionScreen : MonoBehaviour 
{
    private Enums.Character Selection = Enums.Character.None;
    public void CharacterPressed(string CharacterSelected)
    {
        Enums.Character Character = (Enums.Character)System.Enum.Parse(typeof(Enums.Character), CharacterSelected);
        GameManager.GM.SetCharacterSelected(Character);
    }
    public void PlayPressed(string SceneToLoad)
    {
        GameManager.GM.LoadScene(SceneToLoad);
    }
    public void OnBackPresed()
    {
        Application.LoadLevel("MainMenuScene"); // Should make everything FRESH
    }
}
