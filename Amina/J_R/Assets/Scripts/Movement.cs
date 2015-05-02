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
    void FixedUpdate() // Do not delete these contents - read through it all, you will combine into your own movement code
    {
        /* >>>! Matthew Wayne - Raycasts are costly
                Why not use a box collider the size of the player instead? See Hierarchy for ObjectSenser under Player
                See OnTriggerEnter() method
         *      Probably should also make the Object senser shaped like a cone rather than a box lol
         */
        // Raycasting Code
        /*RaycastHit hit;
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
        }*/
        
        // Basic move forward
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2.50f);
        }
        //Basic move back
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2.50f);
        }
        // Basic rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, -45.0f * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, 45.0f * Time.deltaTime, 0.0f);
        }
    }
}