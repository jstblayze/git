// Author: Amina Khalique
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class PickableObject : MonoBehaviour
{
    public string PickableObjectName;
    public string PickableItemCategory;
    public GameObject Prompt;
    void Update()
    {
        // Makes the object glow when it's in camera/ player view :)
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
        {
            ToggleHalo(true);
        }
        else
        {
            ToggleHalo(false);
        }
    }
    public void TogglePlayerInPickupRange(bool Toggle)
    {
        switch (Toggle)
        {
            case true:
                Prompt.SetActive(true);
                Prompt.GetComponentInChildren<Text>().text = "Pickup " + PickableObjectName;
                ZoneManager.PickableIsInRange = true;
                ZoneManager.PickableObjectInRange = this;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case false:
                Prompt.GetComponentInChildren<Text>().text = "";
                Prompt.SetActive(false);
                ZoneManager.PickableIsInRange = true;
                ZoneManager.PickableObjectInRange = null;
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }
    public void ToggleHalo(bool Toggle)
    {
        Behaviour h = (Behaviour)GetComponent("Halo");
        h.enabled = Toggle;
    }
    public string GetPickableObjectName()
    {
        return PickableObjectName;
    }
    public void AddPickableToInventory()
    {
        Debug.Log("/////");
        Debug.Log("" + PickableObjectName + " " + PickableItemCategory);
        ZoneManager.InventoryScreen.AddItemToInventory(PickableObjectName, PickableItemCategory);
        Destroy(gameObject);
    }
}
