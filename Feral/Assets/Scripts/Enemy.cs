// Author: Amina Khalique
// >>>!Agbolade Blaize : Combine this script with your code - Do not delete things I have
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour 
{
    public string Name;
    public Enums.Enemy EnemyType;
    public int Health;
    private bool IsDead = false;
	void Start () 
    {
	}
	void Update () 
    {
        if (Health == 0)
        {
            if (!IsDead) // So that it only does it once
            {
                //Play Animation:
                //ZoneManager.AnimationManager.PlayEnemyAnimation(EnemyType, Enums.EAnimationType.Death); // Animation manager is not complete - Matthew Whitely
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                IsDead = true;
            }
        }
	}
    public bool Died()
    {
        return IsDead;
    }
    public Enums.Enemy GetEnemyType()
    {
        return EnemyType;
    }
    public void SetEnemyName(string EnemyName)
    {
        Name = EnemyName;
    }
    public string GetEnemyName()
    {
        return Name;
    }
    public int GetHealth()
    {
        return Health;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}