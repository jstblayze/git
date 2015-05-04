using UnityEngine;
using System.Collections;

public class SelectionScreen : MonoBehaviour 
{
    private Enums.Character Selection = Enums.Character.None;
    public void JacksonPressed()
    {
        Selection = Enums.Character.Jackson;
    }
    public void RyleyPressed()
    {
        Selection = Enums.Character.Ryley;
    }
    public void PlayPressed()
    {
        if(Selection != Enums.Character.None)
        {
            GameManager.CharacterSelected = Selection;
            Application.LoadLevel("GameScene");
        }
    }
    public void OnBackPresed()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
