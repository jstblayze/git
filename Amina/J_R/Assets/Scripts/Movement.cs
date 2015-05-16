//Author: Amina Khalique
//>>>! Matthew Wayne 
using UnityEngine;
using System.Collections;
public class Movement : MonoBehaviour 
{
    public GameObject Inventory;
    public void Start()
    {
        Inventory.SetActive(false);
    }
    void FixedUpdate() // Or update?
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2.50f);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2.50f);
        }
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