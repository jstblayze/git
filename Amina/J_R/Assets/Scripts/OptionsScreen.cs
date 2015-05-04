using UnityEngine;
using System.Collections;

public class OptionsScreen : MonoBehaviour 
{
    public void OnSaveSettingsPressed()
    {
        // Save Settings to cache
        Application.LoadLevel("MainMenuScene");
    }
    public void OnBackPressed()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
