//Author: Amina Khalique
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Toggle Inventory Screen Off");
            InventoryScreen.SetActive(false);
        }
        if(Input.GetKeyDown("y")) // Ask matt if it would be here?
        {
            Debug.Log("Toggle Inventory Screen On");
            InventoryScreen.SetActive(true);
        }
       
    }
}
