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
    }
    public void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.tag.Contains("Enemy") || Collider.gameObject.tag.Contains("Container")) // Lootable Object
        {
            // Player is not close enough
            LootableObject LootableObject = Collider.gameObject.GetComponent<LootableObject>();
            LootableObject.TogglePlayerInLootingRange(false);
        }
    }
}
