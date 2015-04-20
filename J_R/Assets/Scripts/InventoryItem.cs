using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public RectTransform Panel; // what a bunch of fucking morons!
    public Text LootText;
    private string LootName;
    private string ItemImage;
    /* public InventoryItem(string LootName)
    {
        this.LootName = LootName;
        Debug.Log("LootName:" + LootName);
        // Decide ItemImage Here:
    }*/
    public void SetLootName(string Name)
    {
        LootName = Name;
        LootText.text = LootName;
    }
	void Start () 
    {
        //LootText.text = "BLAHADasljdhflaksjdf";
        /*Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform T in ts)
        {
            Debug.Log(T.name);
        }*/
	}
	void Update () 
    {
	}
}
