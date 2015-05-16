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
            Room1.PlayerInHere = false;
            Room2.PlayerInHere = true;
            Room2.ShowEnemies();
            Room1.HideEnemies();
        }
        else if(Room2.PlayerInHere)
        {
            Room2.PlayerInHere = false;
            Room1.PlayerInHere = true;
            Room1.ShowEnemies();
            Room2.HideEnemies();
        }
    }
}
