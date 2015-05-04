using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour 
{
    public GameObject PlayOrNewGame;
    public GameObject Continue;
	void Start () 
    {
	    // Check whether there is saved data and change main screen buttons Play/Continue if required
	}
	void Update () 
    {
	
	}
    public void OnPlayOrNewGamePressed()
    {
        Application.LoadLevel("CharacterSelectionScene");
    }
    public void OnContinuePresed()
    {
        Application.LoadLevel("LoadScreenScene");
    }
    public void OnOptionsPresed()
    {
        Application.LoadLevel("OptionsScene");
    }
    public void OnCreditsPressed()
    {
        Application.LoadLevel("CreditsMenuScene");
    }
    public void OnQuitPresed()
    {
        Application.Quit();
    }
}
