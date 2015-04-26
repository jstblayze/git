using UnityEngine;
using System.Collections;

public class Enums
{
    public enum Item
    {
        Pistol,
        MachineGun,
        Rifle,
        PistolBullets,
        MachineGunBullets,
        RifleBullets,
        Vaccine1,
        Vaccine2,
        Zone_A_Key,
        // Map Items
        Zone1,
        Zone2,
        Zone3
    }
    public enum Character
    {
        Jackson,
        Ryley
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
}
