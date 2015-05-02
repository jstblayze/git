//Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour 
{
    public static Character Character;
    public static Movement Movement;
    public static InventoryScreen InventoryScreen;
    public static LootableInventoryScreen LootableInventoryScreen;
    public static LootManager LootManager;
    public static Enums.ActiveUI CurrentlyActiveUI;
    public static bool ObjectInLootingRange;
    public static LootableObject ObjectInLootRange;

    public GameObject Inventory;
    public GameObject Loot;
    public GameObject LootScreen;
    public GameObject LootPrompt;

	void Awake () // Runs before anything else
    {
        // Check if save game stuff exists - If it does -> reflect on Main Screen Buttons

        LootPrompt.SetActive(false);
        ObjectInLootRange = null;
        ObjectInLootingRange = false;

        Character = GameObject.Find("Player").GetComponent<Character>();
        Movement = GameObject.Find("Player").GetComponent<Movement>();

        InventoryScreen = GameObject.Find("InventoryScreen").GetComponent<InventoryScreen>();
        LootableInventoryScreen = LootScreen.GetComponent<LootableInventoryScreen>();
        LootManager = gameObject.GetComponent<LootManager>();

        Loot.SetActive(false);
	}
    // Activating/ Deactivating Screens
	void Update () 
    {
        // Exit any pop up screen
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch(CurrentlyActiveUI)
            {
                case Enums.ActiveUI.InventoryScreen:
                    Inventory.SetActive(false);
                    CurrentlyActiveUI = Enums.ActiveUI.None;
                    break;
                case Enums.ActiveUI.LootScreen:
                    Loot.SetActive(false);
                    CurrentlyActiveUI = Enums.ActiveUI.None;
                    break;
                case Enums.ActiveUI.PauseScreen:
                    CurrentlyActiveUI = Enums.ActiveUI.None;
                    break;
            }
        }
        // Open Inventory Screen Y
        if (Input.GetKeyDown(KeyCode.Y) && CurrentlyActiveUI == Enums.ActiveUI.None)
        {
            Inventory.SetActive(true);
            CurrentlyActiveUI = Enums.ActiveUI.InventoryScreen;
            InventoryScreen.OnOpenInventoryScreen();
        }
        // Close Inventory Screen Y
        else if(Input.GetKeyDown(KeyCode.Y) && CurrentlyActiveUI == Enums.ActiveUI.InventoryScreen)
        {
            Inventory.SetActive(false);
            CurrentlyActiveUI = Enums.ActiveUI.None;
        }
        // Open Loot Screen F
        if (Input.GetKeyDown(KeyCode.F) && CurrentlyActiveUI == Enums.ActiveUI.None && 
            ObjectInLootingRange && ObjectInLootRange != null)
        {
            ObjectInLootRange.OnBeingLooted();
        }
        // Close Loot Screen F
        else if(Input.GetKeyDown(KeyCode.F) && CurrentlyActiveUI == Enums.ActiveUI.LootScreen)
        {
            Loot.SetActive(false);
            CurrentlyActiveUI = Enums.ActiveUI.None;
        }
	}
    public GameObject GetInventoryScreen()
    {
        return Inventory;
    }
    public GameObject GetLootScreen()
    {
        return Loot;
    }
    public LootableInventoryScreen GetLootableInventoryPanel()
    {
        return LootableInventoryScreen;
    }
}
