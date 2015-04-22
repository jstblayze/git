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

    public static bool LootableScreenInventoryOpen;
    public static bool InventoryScreenOpen;
    public static bool PauseScreenOpen;

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
	}
}
