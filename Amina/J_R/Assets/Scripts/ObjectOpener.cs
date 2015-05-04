// Author: Amina Khalique
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
            InteractableObject InteractableObject = Collider.gameObject.GetComponent<InteractableObject>();
            InteractableObject.TogglePlayerInInteractingRange(true);
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
            InteractableObject InteractableObject = Collider.gameObject.GetComponent<InteractableObject>();
            InteractableObject.TogglePlayerInInteractingRange(false);
        }
    }
}
