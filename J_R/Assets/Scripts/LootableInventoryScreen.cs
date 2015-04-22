//Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LootableInventoryScreen : MonoBehaviour
{
    public RectTransform Panel; // Whoever thought of this is a fucking moron - call it a PANEL! 
    public GameObject PreFab_InventoryItem;
    private bool ShowInventory;
    public GameObject UIWindow;
	void Start () 
    {
        //ShowInventory = false;
	}
	void Update () 
    {
	}
    public void ShowInventoryScreen(bool ToShow)
    {
        //ShowInventory = ToShow;
    }
    public void AddToCanvas(string ItemName)
    {
        InventoryItem InventoryItem = PreFab_InventoryItem.GetComponent<InventoryItem>();
        InventoryItem.SetLootName(ItemName);

        GameObject IItem = (GameObject)Instantiate(PreFab_InventoryItem, new Vector3(5.5f,5.5f), Quaternion.identity);
        IItem.transform.SetParent(Panel.transform);
    }
}
