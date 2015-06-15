// Author : Amina Khalique
using UnityEngine;
using System.Collections;
public class Door : MonoBehaviour 
{
    public string DoorName;
    public Enums.DoorType DoorType;
    public Enums.DoorState DoorState;
    public string KeyRequired;
    public Room Room1;
    public Room Room2;
    public const float INVISIBLE_MAX = 2.0f;
    public float Timer = 0.0f;
    public bool Opened = false;
    public bool UnlockDoor()
    {
        if(ZoneManager.InventoryScreen.HasKey(KeyRequired))
        {
            DoorState = Enums.DoorState.Unlocked;
            return true;
        }
        return false;
    }
    public void Update()
    {
        if(Opened)
        {
            if(Timer <= INVISIBLE_MAX)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                Timer = 0.0f;
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                Opened = false;
            }
        }
    }
    public void ActivateDoor()
    {
        // Turn off the box collider
        gameObject.GetComponent<InteractableObject>().TogglePlayerInInteractingRange(false);

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        
        Opened = true;
        Debug.Log("Activated Door");
        if(DoorName.Contains("Regular"))
        {
            if (Room1 != null && Room1.PlayerInHere)
            {
                DeleteDeadEnemies(Room1);
                Room1.PlayerInHere = false;
                Room2.PlayerInHere = true;
                Room2.ShowEnemies();
                Room1.HideEnemies();
            }
            else if (Room2 != null && Room2.PlayerInHere)
            {
                DeleteDeadEnemies(Room2);
                Room2.PlayerInHere = false;
                Room1.PlayerInHere = true;
                Room1.ShowEnemies();
                Room2.HideEnemies();
            }
        }
        else if(DoorName.Contains("Zone"))
        {
            DontDestroyOnLoad(GameObject.Find("GameManager"));
            DontDestroyOnLoad(GameObject.Find("Player1"));
            Application.LoadLevel(DoorName);
        }        
    }
    public void DeleteDeadEnemies(Room Room)
    {
        for (int i = 0; i < Room.GetEnemiesInRoom().Count; i++)
        {
            if (Room.GetEnemiesInRoom()[i].GetHealth() == 0)
            {
                Room.GetEnemiesInRoom()[i].Destroy();
                Room.EnemyToDeleteIndex = i;
            }
        }
    }
}
