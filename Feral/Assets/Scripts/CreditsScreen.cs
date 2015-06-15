// Author : Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreditsScreen : MonoBehaviour 
{
    public GameObject CreditsPanel;
    public float Speed;
    public float Timer = 0;
    public float FinalTime;
    private Vector2 StartPos;
	void Start () 
    {
        StartPos = CreditsPanel.transform.position;
	}
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenuScene");
        }
        if(Timer > FinalTime)
        {
            CreditsPanel.transform.position = StartPos;
            Timer = 0;
        }
        Timer += Time.deltaTime;
        CreditsPanel.transform.Translate(Vector2.up * Time.deltaTime * Speed);
	}
    public void OnBackPressed()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
