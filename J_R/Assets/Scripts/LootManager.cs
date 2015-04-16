using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LootManager : MonoBehaviour 
{
    // Holds percetages of a lootable item having 0, 1, 2, 3, 4, 5 items on it during loot
    public Dictionary<int, int[]> ItemMaxReferenceDatabase;
	void Start () 
    {
	    ItemMaxReferenceDatabase.Add(1000, new int[] { 20, 20, 20, 20, 20} );
        ItemMaxReferenceDatabase.Add(1010, new int[] { 20, 20, 20, 20, 20 });
        ItemMaxReferenceDatabase.Add(1020, new int[] { 20, 20, 20, 20, 20 });
        ItemMaxReferenceDatabase.Add(2000, new int[] { 20, 20, 20, 20, 20 });
        ItemMaxReferenceDatabase.Add(2010, new int[] { 20, 20, 20, 20, 20 });
        ItemMaxReferenceDatabase.Add(2020, new int[] { 20, 20, 20, 20, 20 });

        //Create
	}
	void Update () 
    {
	
	}
}
