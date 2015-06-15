// Author : Amina Khalique
using UnityEngine;
using System.Collections;
public class Enums
{
    public enum DoorState
    {
        Locked,
        Unlocked
    }
    public enum DoorType
    {
        Regular,
        CardReaderDoor
    }
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
        Komodo
    }
    public enum Weapon
    {
        Pistol,
        MachineGun,
        Rifle,
        Claws,
        MetalPipe,
        Knife,
        Reminder
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
    //>>>! Matthew Whitely - You will probably find these helpful
    public enum RyleyAnim
    {
        RyleyDeath,
        RyleyFeralDeath,
        RyleyRun,
        RyleyClawSwipe,
        RyleyPipeSwing,
        RyleyReminderSwing,
        RyleyKnifeStab,
        RyleyJumpForward,
        RyleyInjuryStagger
    }
    public enum GeckoAnim
    {
        GeckoDeath,
        GeckoAttack,
        GeckoInjuryStagger
    }
    public enum EAnimationType
    {
        Death,
        Attack,
        InjuryStagger
    }
}
