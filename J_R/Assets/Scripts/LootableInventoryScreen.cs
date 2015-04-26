//Author: Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LootableInventoryScreen : MonoBehaviour
{
    public RectTransform Panel; // Whoever thought of this is a fucking moron - call it a PANEL! 
    public GameObject PreFab_InventoryItem;
    public GameObject PreFab_InventoryItemPanel;
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
        InventoryItem InventoryItem = PreFab_InventoryItemPanel.GetComponent<InventoryItem>();
        InventoryItem.SetLootName(ItemName);

        GameObject IIP = (GameObject)Instantiate(PreFab_InventoryItemPanel, transform.position, Quaternion.identity);
        IIP.transform.SetParent(Panel.transform);
    }
}
