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

    public  GameObject Inventory;
    public  GameObject Loot;

	void Awake () // Runs before anything else
    {
        Character = GameObject.Find("Player").GetComponent<Character>();
        Movement = GameObject.Find("Player").GetComponent<Movement>();

        InventoryScreen = GameObject.Find("InventoryScreen").GetComponent<InventoryScreen>();
        LootableInventoryScreen = GameObject.Find("LootableInventoryScreen").GetComponent<LootableInventoryScreen>();
        LootManager = gameObject.GetComponent<LootManager>();
	}
	void Update () 
    {
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
	}
    public GameObject GetInventoryScreen()
    {
        return Inventory;
    }
    public GameObject GetLootScreen()
    {
        return Loot;
    }
}
