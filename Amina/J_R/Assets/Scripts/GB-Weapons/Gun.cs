//Author: Blaize Gbolade
using UnityEngine;
using System.Collections;

public class Gun : Weapon {
    public GameObject Bullet;

    Gun gun1 = new Gun
    {
        Name = "Assualt Rifle",
        Weight = 5,
        itemId = 1,
        Rarity = RarityTypes.Rare,
        fireRate = 4.0f,
        reloadTime = 3.0f,
        Ammunition = 20,
        CharacterInUse = 0
    };

    Gun gun2 = new Gun
    {
        Name = "Pistol",
        Weight = 3,
        itemId = 2,
        Rarity = RarityTypes.Common,
        fireRate = 2.0f,
        reloadTime = .5f,
        Ammunition = 10,
        CharacterInUse = 1
    };

    Gun gun3 = new Gun
    {
        Name = "Machine Gun",
        Weight = 1,
        itemId = 3,
        Rarity = RarityTypes.Average,
        fireRate = 5.0f,
        reloadTime = 2.5f,
        Ammunition = 15,
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
