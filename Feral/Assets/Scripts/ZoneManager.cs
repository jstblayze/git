//Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class ZoneManager : MonoBehaviour 
{
    private GameManager GameManager; 
    
    public string ZoneName;
    public Vector3 EntrancePoint;
   
    public GameObject Prompt;
    public GameObject Inventory;
    public GameObject Loot;
    public GameObject LootScreen;

    public static Enums.ActiveUI ActiveUI;
    
    public static InventoryScreen InventoryScreen;
    public static LootableInventoryScreen LootableInventoryScreen;

    public static bool ObjectInLootingRange;
    public static LootableObject ObjectInLootRange;

    public static bool InteractableIsInRange;
    public static InteractableObject InteractableObjectInRange;

    public static bool PickableIsInRange;
    public static PickableObject PickableObjectInRange;

    private Vector3 LoadPoint;

    public static Character Character;
    public void Awake()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        ActiveUI = Enums.ActiveUI.None;
        if (GameManager.GetSavedPosition() != null) // A Saved Position Exists
        {
            LoadPoint = GameManager.GetSavedPosition();
        }
        else
        {
            LoadPoint = EntrancePoint;
        }

        ObjectInLootRange = null;
        ObjectInLootingRange = false;

        InteractableIsInRange = false;
        InteractableObjectInRange = null;

        PickableIsInRange = false;
        PickableObjectInRange = null;

        InventoryScreen = Inventory.GetComponent<InventoryScreen>();
        LootableInventoryScreen = LootScreen.GetComponent<LootableInventoryScreen>();

        Loot.SetActive(false);
        Prompt.SetActive(false);

        Character = GameObject.Find("Robot").GetComponent<Character>();
    }
    void Update()
    {
        // Exit any pop up screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (ActiveUI)
            {
                case Enums.ActiveUI.InventoryScreen:
                    Inventory.SetActive(false);
                    ActiveUI = Enums.ActiveUI.None;
                    break;
                case Enums.ActiveUI.LootScreen:
                    Loot.SetActive(false);
                    ActiveUI = Enums.ActiveUI.None;
                    break;
                case Enums.ActiveUI.PauseScreen:
                    ActiveUI = Enums.ActiveUI.None;
                    break;
            }
        }
        // Open Inventory Screen I
        if (Input.GetKeyDown(KeyCode.I) && ActiveUI == Enums.ActiveUI.None)
        {
            Inventory.SetActive(true);
            ActiveUI = Enums.ActiveUI.InventoryScreen;
            InventoryScreen.OnOpenInventoryScreen();
        }
        // Close Inventory Screen I
        else if (Input.GetKeyDown(KeyCode.I) && ActiveUI == Enums.ActiveUI.InventoryScreen)
        {
            Inventory.SetActive(false);
            ActiveUI = Enums.ActiveUI.None;
        }

        // Actions
        // Open Loot Screen Space
        if (Input.GetKeyDown(KeyCode.Space) && ActiveUI == Enums.ActiveUI.None &&
            ObjectInLootingRange && ObjectInLootRange != null) //Applies to Containers & Enemies
        {
            ObjectInLootRange.TogglePlayerInLootingRange(true);
            ObjectInLootRange.OnBeingLooted();
        }
        // Close Loot Screen Space
        else if (Input.GetKeyDown(KeyCode.Space) && ActiveUI == Enums.ActiveUI.LootScreen)
        {
            Loot.SetActive(false);
            ActiveUI = Enums.ActiveUI.None;
        }
        // Interactable Objects Space
        if (Input.GetKeyDown(KeyCode.Space) && InteractableIsInRange && InteractableObjectInRange != null)
        {
            InteractableObjectInRange.PerformAppropriateBehavior();
        }
        //Pickable Objects Space
        if (Input.GetKeyDown(KeyCode.Space) && PickableIsInRange && PickableObjectInRange != null)
        {
            PickableObjectInRange.AddPickableToInventory();
        }
    }
    public GameObject GetInventory()
    {
        return InventoryScreen.gameObject;
    }
    public void SetInventory(GameObject In)
    {
        Inventory = In;
    }
    public GameObject GetLootScreen()
    {
        return Loot;
    }
    public void SetLoot(GameObject InLoot)
    {
        Loot = InLoot;
    }
    public GameObject GetPrompt()
    {
        return Prompt;
    }
    public void SetPrompt(GameObject InPrompt)
    {
        Prompt = InPrompt;
    }
    public static LootableInventoryScreen GetLootableInventoryPanel()
    {
        return LootableInventoryScreen;
    }
}
