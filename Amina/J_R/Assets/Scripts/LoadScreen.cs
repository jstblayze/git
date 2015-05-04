// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class LoadScreen : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadPressed()
    {

    }
    public void BackPressed()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
