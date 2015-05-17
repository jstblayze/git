using UnityEngine;
using System.Collections;

public enum RarityType { Common, Average, Rare }
public class VaccineClass : MonoBehaviour {

    private string name;
    private int SpawnRate;
    private int SpawnLocation;
    private int Health = 0;
    private int[] CharacterInUse = new int[1];
    private string[] Character = { "Jackson", "Riley" };

	// Use this for initialization
	public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public int Spawnrate
    {
        set { SpawnRate = value; }
        get { return SpawnRate; }
    }

    public int Spawnlocations
    {
        set { SpawnLocation = value; }
        get { return SpawnLocation; }
    }

    public int health
    {
        set { Health = Health + 25; }
        get { return Health; }
    }

    public int CharacterIU
    {
        set { CharacterInUse[1] = value;}
        get { return CharacterInUse[1]; }
        //set
        //{
        //    for (int x = 0; x <= CharacterInUse.Length; x++ )
        //    {
        //      if(CharacterInUse[x] == 0)
        //      {
        //          //x = Character[0];
        //      }
        //      else if (CharacterInUse[x] == 1)
        //      {

        //      }
        //    }
        //}

        //get { return CharacterInUse[x]; }
    }
}
