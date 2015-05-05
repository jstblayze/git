﻿//Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour 
{
    public static Enums.Character CharacterSelected;

    public static Character Character;
    public static Movement Movement;
    public static InventoryScreen InventoryScreen;
    public static LootableInventoryScreen LootableInventoryScreen;
    public static LootManager LootManager;
    public static Enums.ActiveUI CurrentlyActiveUI;

    public static bool ObjectInLootingRange;
    public static LootableObject ObjectInLootRange;

    public static bool InteractableIsInRange;
    public static InteractableObject InteractableObjectInRange;

    public static bool PickableIsInRange;
    public static PickableObject PickableObjectInRange;

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

        InteractableIsInRange = false;
        InteractableObjectInRange = null;

        PickableIsInRange = false;
        PickableObjectInRange = null;

        Character = GameObject.Find("Player").GetComponent<Character>();
        Movement = GameObject.Find("Player").GetComponent<Movement>();

        InventoryScreen = GameObject.Find("InventoryScreen").GetComponent<InventoryScreen>();
        LootableInventoryScreen = LootScreen.GetComponent<LootableInventoryScreen>();
        LootManager = gameObject.GetComponent<LootManager>();

        Loot.SetActive(false);
	}
    // Activating/ Deactivating Screens
	void Update ()  // This might need to be moved to an "inputs" script or something 
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
        // Open Inventory Screen I
        if (Input.GetKeyDown(KeyCode.I) && CurrentlyActiveUI == Enums.ActiveUI.None)
        {
            Inventory.SetActive(true);
            CurrentlyActiveUI = Enums.ActiveUI.InventoryScreen;
            InventoryScreen.OnOpenInventoryScreen();
        }
        // Close Inventory Screen I
        else if(Input.GetKeyDown(KeyCode.I) && CurrentlyActiveUI == Enums.ActiveUI.InventoryScreen)
        {
            Inventory.SetActive(false);
            CurrentlyActiveUI = Enums.ActiveUI.None;
        }
        // Actions
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
        // Interactable Objects
        if(Input.GetKeyDown(KeyCode.F) && InteractableIsInRange && InteractableObjectInRange != null)
        {
            InteractableObjectInRange.PerformAppropriateBehavior();
        }
        //Pickable Objects
        if (Input.GetKeyDown(KeyCode.F) && PickableIsInRange && PickableObjectInRange != null)
        {
            PickableObjectInRange.AddPickableToInventory();
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
