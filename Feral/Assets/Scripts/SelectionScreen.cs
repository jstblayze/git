// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class SelectionScreen : MonoBehaviour 
{
    private Enums.Character Selection = Enums.Character.None;
    GameManager GameManager;
    public void Awake()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void CharacterPressed(string CharacterSelected)
    {
        Debug.Log("Character Selected -> " + CharacterSelected);
        Enums.Character Character = (Enums.Character)System.Enum.Parse(typeof(Enums.Character), CharacterSelected);
        Debug.Log("Character Parsed -> " + Character.ToString());
        GameManager.SetCharacterSelected(Character);
    }
    public void PlayPressed(string SceneToLoad)
    {
        GameManager.LoadScene(SceneToLoad);
    }
    public void OnBackPresed()
    {
        Application.LoadLevel("MainMenuScene"); // Should make everything FRESH
    }
}
