using UnityEngine;
using System.Collections;

public class ObjectOpener : MonoBehaviour
{
    public void OnTriggerEnter(Collider Collider)
    {
        Debug.Log("ObjectOpener.cs->OnTriggerEnter():" + Collider.gameObject);
        if (Collider.gameObject.tag.Contains("Enemy") || Collider.gameObject.tag.Contains("Container"))
        {
            // Player is sensing the object
            LootableObject LootableObject = Collider.gameObject.GetComponent<LootableObject>();
            LootableObject.TogglePlayerInLootingRange(true);
        }
    }
    public void OnTriggerExit(Collider Collider)
    {
        Debug.Log("ObjectOpener.cs->OnTriggerExit():" + Collider.gameObject);
        if (Collider.gameObject.tag.Contains("Enemy") || Collider.gameObject.tag.Contains("Container"))
        {
            // Player is not sensing the object
            LootableObject LootableObject = Collider.gameObject.GetComponent<LootableObject>();
            LootableObject.TogglePlayerInLootingRange(false);
        }
    }
}
