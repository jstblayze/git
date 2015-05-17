//Author: Blaize Gbolade
using UnityEngine;
using System.Collections;

public class Gun : Weapon {
    public GameObject Bullet;

    Gun gun1 = new Gun
    {
        Name = "Assualt Rifle",
        Weight = 2,
        itemId = 1,
        Rarity = RarityTypes.Rare,
        fireRate = 2.0f,
        reloadTime = .25f,
        Ammunition = 20,
        CharacterInUse = 0
    };

    Gun gun2 = new Gun
    {
        Name = "Pistol",
        Weight = 2,
        itemId = 1,
        Rarity = RarityTypes.Common,
        fireRate = 1.0f,
        reloadTime = .5f,
        Ammunition = 5,
        CharacterInUse = 1
    };

    Gun gun3 = new Gun
    {
        Name = "Pistol",
        Weight = 2,
        itemId = 1,
        Rarity = RarityTypes.Common,
        fireRate = 1.0f,
        reloadTime = .5f,
        Ammunition = 5,
        CharacterInUse = 1
    };
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject clone = (GameObject) Instantiate(Bullet, transform.position, transform.rotation);
            
        }
    }
}
