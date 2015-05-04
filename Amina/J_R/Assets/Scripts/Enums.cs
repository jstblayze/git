using UnityEngine;
using System.Collections;

public class Enums
{
    public enum Item
    {
        // Jackson Weapons
        Pistol,
        MachineGun,
        Rifle,
        PistolBullets,
        MachineGunBullets,
        RifleBullets,

        // Ryley Weapons
        MetalPipe,
        Reminder,
        Knife,

        // Items
        Vaccine1,
        Vaccine2,
        Zone_A_Key,
        
        // Map Items
        Zone1,
        Zone2,
        Zone3,

        // UI Specific
        Pickup,
        Drop
    }
    public enum Character
    {
        None,
        Ryley,
        Jackson
    }
    public enum Enemy
    {
        Tiger,
        Gecko,
        Komodo,
        Lizard
    }
    public enum Weapon
    {
        Pistol,
        MachineGun,
        Rifle,
        Claws,
        MetalPipe,
        Knife
    }
    public enum ActiveUI
    {
        None,
        LootScreen,
        InventoryScreen,
        PauseScreen
    }
    public enum Interactable
    {
        Door,
        Computer,
        SciFiDoor,
        CardReader
    }
}
