using UnityEngine;
using System.Collections;

public class ObjectSenser : MonoBehaviour 
{
    public void OnCollisionEnter(Collision Collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(Collision.gameObject);
        if (Collision.gameObject.tag.Contains("Enemy") || Collision.gameObject.tag.Contains("Container"))
        {
            // Player is sensing the object
            LootableObject LootableObject = Collision.gameObject.GetComponent<LootableObject>();
            LootableObject.ToggleHalo(true);
        }
    }
    public void OnCollisionExit(Collision Collision)
    {
        Debug.Log("OnCollisionExit");
        Debug.Log(Collision.gameObject);
        if (Collision.gameObject.tag.Contains("Enemy") || Collision.gameObject.tag.Contains("Container"))
        {
            // Player is not sensing the object
            LootableObject LootableObject = Collision.gameObject.GetComponent<LootableObject>();
            LootableObject.ToggleHalo(false);
        }
    }
}
