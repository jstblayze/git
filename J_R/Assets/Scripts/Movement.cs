//Author: Amina Khalique
//>>>!Matthew Wayne - Combine this script with your code
using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour 
{
    public GameObject InventoryScreen;
    // Dummy class - will be replaced by Matthew Wayne 
	void Start () 
    {
        InventoryScreen.SetActive(false);
	}
    void FixedUpdate() // Do not delete these contents 
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Toggle Inventory Screen Off");
            InventoryScreen.SetActive(false);
            GameManager.CurrentlyActiveUI = Enums.ActiveUI.None;
        }*/
        if(Input.GetKeyDown("y") && GameManager.CurrentlyActiveUI != Enums.ActiveUI.LootScreen) // >>>! Matthew Wayne : Would these input controls be here?
        {
            InventoryScreen.SetActive(true);
            GameManager.CurrentlyActiveUI = Enums.ActiveUI.InventoryScreen;
        }
       
    }
}
