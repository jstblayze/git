//Author: Amina Khalique
//>>>! Matthew Wayne - Combine this script with your code
using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour 
{
    public GameObject InventoryScreen;
    public int DistanceToObject = 10;
    private Color DrawColor;
    
    // Dummy class - will be replaced by Matthew Wayne 
	void Start () 
    {
        DrawColor = Color.green;
        InventoryScreen.SetActive(false);
	}
    void FixedUpdate() // Do not delete these contents 
    {
        // Casts a ray ahead of yourself - 
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 1, DrawColor, 1);
        if (Physics.Raycast(transform.position, transform.forward, out hit)) // Casts a rayforward - stores info in hit
        {
            if(hit.distance <= 1) // You hit something within 1 units of yourself
            {
                DrawColor = Color.red;
                Debug.Log("You hit something!");
                Debug.Log(hit.transform.gameObject.name); 
                // Make the item glow
                hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                DrawColor = Color.green;
            }
        }
        if(Input.GetKeyDown("y") && GameManager.CurrentlyActiveUI != Enums.ActiveUI.LootScreen) // >>>! Matthew Wayne : Would these input controls be here?
        {
            InventoryScreen.SetActive(true);
            GameManager.CurrentlyActiveUI = Enums.ActiveUI.InventoryScreen;
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2.50f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2.50f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating Right?");
            transform.Rotate(0.0f, -30.0f * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating Left?");
            transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
        }

    }
}
