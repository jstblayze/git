//Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LootableInventoryScreen : MonoBehaviour
{
    public RectTransform Panel; // Whoever thought of this is a fucking moron - call it a PANEL! 
    public GameObject PreFab_InventoryItemPanel;
    public GameObject NO_ITEMS;
    private bool ShowInventory;   
	void Start () 
    {
        NO_ITEMS.SetActive(false);
        //ShowInventory = false;
	}
	void Update () 
    {
	}
    public void SetNoItems(bool ToShow)
    {
        NO_ITEMS.SetActive(ToShow);
    }
    public void ShowInventoryScreen(bool ToShow)
    {
        //ShowInventory = ToShow;
    }
    public void AddToCanvas(string ItemName)
    {
        InventoryItem InventoryItem = PreFab_InventoryItemPanel.GetComponent<InventoryItem>();
        InventoryItem.SetLootName(ItemName);
        InventoryItem.SetPickupOrDrop(Enums.Item.Pickup);

        GameObject IIP = (GameObject)Instantiate(PreFab_InventoryItemPanel, transform.position, Quaternion.identity);
        IIP.transform.SetParent(Panel.transform);
    }
}
