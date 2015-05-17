//Blaize Gbolade
using UnityEngine;

public enum RarityTypes { Common, Average, Rare }
public class Weapon: MonoBehaviour {
  
        protected string _name;
        protected int _WeaponId;
        protected RarityTypes _rarity;
        protected int _weight;
        protected int _Ammo;
        protected int _Damage;
        protected float _ReloadTime;
        protected float _FireRate;
        protected float _SpawnRate;
        protected int _SpawnLocations;
        protected bool Upgradeable;
        protected int _CharacterId;

        //public Weapon()
        //{
        //    _name = "Gun";
        //    _WeaponId = 0;
        //    _rarity = RarityTypes.Common;
        //    _weight = 5;
        //    _Ammo = 20;
        //    _Damage = 40;
        //    _ReloadTime = 2.0f;
        //    _FireRate = 0.75f;
        //    _SpawnRate = 0.90f;
        //    _SpawnLocations = 0;
        //    Upgradeable = true;
        //    _CharacterId = 0;
        //    Debug.Log(_name + _CharacterId + _WeaponId + _weight + _Ammo + _rarity);
        //}

        //public Weapon(string name, int WeaponId, RarityTypes rare, int weight, int Ammo, int Damage, float ReloadTime, float FireRate)
        //{
        //    _name = name;
        //    _WeaponId = WeaponId;
        //    _rarity = rare;
        //    _weight = weight;
        //    _Damage = Damage;
        //    _Ammo = Ammo;
        //    _ReloadTime = ReloadTime;
        //    _FireRate = FireRate;

        //}

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int itemId
        {
            get { return _WeaponId; }
            set { _WeaponId = value; }
        }

        public RarityTypes Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
            
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Ammunition
        {
            get { return _Ammo; }
            set { _Ammo = value; }
            
        }

        public int damage
        {
            get { return _Damage; }
            set {_Damage = value;}
           
        }

        public float reloadTime
        {
            get { return _ReloadTime; }
            set{_ReloadTime = value;}
            
        }
        
        public float fireRate
        {
            get { return _FireRate; }
            set{_FireRate = value;}
             
        }

        public float SpawnRates
        {
            get { return _SpawnRate; }
            set { _SpawnRate = value; }
        }

        public int SpawnLocations
        {
            get { return _SpawnLocations; }
            set { _SpawnLocations = value; }
        }

        public bool Upgrade()
        {
            return Upgradeable;
        }

        public int CharacterInUse
        {
            get { return _CharacterId; }
            set { _CharacterId = value; }
        }
    }  
