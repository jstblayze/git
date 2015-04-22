//Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour 
{
    public static Character Character;
    public static Inventory Inventory;
    public static Movement Movement;
    public static InventoryScreen InventoryScreen;
    public static LootableInventoryScreen LootableInventoryScreen;
    public static LootManager LootManager;
	void Awake () // Runs before anything else
    {
        Character = GameObject.Find("Player").GetComponent<Character>();
        Movement = GameObject.Find("Player").GetComponent<Movement>();
        Inventory = GameObject.Find("Player").GetComponent<Inventory>();

        InventoryScreen = GameObject.Find("InventoryScreen").GetComponent<InventoryScreen>();
        LootableInventoryScreen = GameObject.Find("LootableInventoryScreen").GetComponent<LootableInventoryScreen>();
        LootManager = gameObject.GetComponent<LootManager>();
	}
	void Update () 
    {
	}
}
