﻿// Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class ObjectOpener : MonoBehaviour
{
    public void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.tag.Contains("Enemy") || Collider.gameObject.tag.Contains("Container")) // Lootable Object
        {
            // Player is close enough
            LootableObject LootableObject = Collider.gameObject.GetComponent<LootableObject>();
            LootableObject.TogglePlayerInLootingRange(true);
        }
        else if (Collider.gameObject.tag.Contains("Interactable"))
        {
            Debug.Log("Near enough to a door");
            InteractableObject InteractableObject = Collider.gameObject.GetComponent<InteractableObject>();
            InteractableObject.TogglePlayerInInteractingRange(true);
        }
        else if (Collider.gameObject.tag.Contains("Pickable"))
        {
            PickableObject PickableObject = Collider.gameObject.GetComponent<PickableObject>();
            PickableObject.TogglePlayerInPickupRange(true);
        }
    }
    public void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.tag.Contains("Enemy") || Collider.gameObject.tag.Contains("Container")) // Lootable Object
        {
            // Player is not close enough
            LootableObject LootableObject = Collider.gameObject.GetComponent<LootableObject>();
            LootableObject.TogglePlayerInLootingRange(false);
        }
        else if (Collider.gameObject.tag.Contains("Interactable"))
        {
            Debug.Log("Far from a door");
            InteractableObject InteractableObject = Collider.gameObject.GetComponent<InteractableObject>();
            InteractableObject.TogglePlayerInInteractingRange(false);
        }
        else if (Collider.gameObject.tag.Contains("Pickable"))
        {
            PickableObject PickableObject = Collider.gameObject.GetComponent<PickableObject>();
            PickableObject.TogglePlayerInPickupRange(false);
        }
    }
}
