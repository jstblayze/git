// Author : Amina Khalique
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour 
{
    // Room contains the spawn agent
    public bool PlayerInHere;
    public List<Enemy> EnemiesInThisRoom = new List<Enemy>();
    public int EnemyToDeleteIndex = -1; // None to delete when -1
	void Start () 
    {
	    foreach(Enemy Enemy in EnemiesInThisRoom)
        {
            Enemy.gameObject.SetActive(false);
        }
	}
    public void SetEnemiesInThisRoom(List<Enemy> EnemiesInRoom)
    {
        EnemiesInThisRoom = EnemiesInRoom;
    }
    public List<Enemy> GetEnemiesInRoom()
    {
        return EnemiesInThisRoom;
    }
    public void SetEnemyToDelete(int EnemyToDelete)
    {
        EnemyToDeleteIndex = EnemyToDelete;
    }
	void Update () 
    {
        if(EnemyToDeleteIndex != -1) // There's an enemy to remove from the list
        {
            EnemiesInThisRoom.RemoveAt(EnemyToDeleteIndex);
            EnemyToDeleteIndex = -1;
        }
	}
    public void ShowEnemies()
    {
        Debug.Log(gameObject.name + "Showing Enemies");
        foreach (Enemy Enemy in EnemiesInThisRoom)
        {
            Debug.Log(Enemy.GetEnemyName());
            Enemy.gameObject.SetActive(true);
        }
    }
    public void HideEnemies()
    {
        Debug.Log(gameObject.name + "Hiding Enemies");
        foreach (Enemy Enemy in EnemiesInThisRoom)
        {
            Enemy.gameObject.SetActive(false);
        }
    }
}
