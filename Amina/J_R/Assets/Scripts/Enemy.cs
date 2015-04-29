// Author: Amina Khalique
// >>>!Agbolade Blaize : Combine this script with your code
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour 
{
    public string Name;
    public int EnemyID;
	void Start () 
    {
	
	}
	void Update () 
    {
	
	}
    public void SetEnemyID(int ID)
    {
        EnemyID = ID;
    }
    public int GetEnemyID()
    {
        return EnemyID;
    }
    public void SetEnemyName(string EnemyName)
    {
        Name = EnemyName;
    }
    public string GetEnemyName()
    {
        return Name;
    }
}
