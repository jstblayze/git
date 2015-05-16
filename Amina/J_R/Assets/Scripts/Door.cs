// Author : Amina Khalique
using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
    public Room Room1;
    public Room Room2;

	void Start () 
    {
	
	}
	void Update () 
    {
	    
	}
    public void ActivateDoor()
    {
        Debug.Log("Activated Door");
        if(Room1.PlayerInHere)
        {
            DeleteDeadEnemies(Room1);
            Room1.PlayerInHere = false;
            Room2.PlayerInHere = true;
            Room2.ShowEnemies();
            Room1.HideEnemies();
        }
        else if(Room2.PlayerInHere)
        {
            DeleteDeadEnemies(Room2);
            Room2.PlayerInHere = false;
            Room1.PlayerInHere = true;
            Room1.ShowEnemies();
            Room2.HideEnemies();
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
