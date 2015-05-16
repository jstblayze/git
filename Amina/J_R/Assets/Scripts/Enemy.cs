// Author: Amina Khalique
// >>>!Agbolade Blaize : Combine this script with your code
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour 
{
    private const float MAX_LOOT_TIME = 10.0f;
    private float DeathTimer = 0.0f;
    public string Name;
    public Enums.Enemy EnemyType;
    public int Health;
    private Room WhereEnemyIs;
    private int WhichEnemy;
    private bool IsDead = false;
	void Start () 
    {
	
	}
	void Update () 
    {
        if (IsDead)
        {
            if (DeathTimer < MAX_LOOT_TIME)
            {
                DeathTimer += Time.deltaTime;
                Debug.Log("DeathTimer Incrementing: " + DeathTimer);
            }
            else
            {
                Debug.Log("Enemy Killed:");
                WhereEnemyIs.SetEnemyToDelete(WhichEnemy);
                Destroy(gameObject);
            }
        }
	}
    public bool IsEnemyDead()
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
    public void PlayDeathAnimation()
    {
        // Play required animation based on parameters
    }
    public void Destroy(Room WhereEnemyIs, int WhichEnemy)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        IsDead = true;
        this.WhereEnemyIs = WhereEnemyIs;
        this.WhichEnemy = WhichEnemy;
    }
}
