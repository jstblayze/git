using UnityEngine;
using System.Collections;

public class CardReader : MonoBehaviour 
{
    public string KeyRequired;
    public Door Door; // Direct interaction between cardreader and Door
	
    public bool ScanCard()
    {
        if(ZoneManager.InventoryScreen.HasKey(KeyRequired))
        {
            Door.DoorState = Enums.DoorState.Unlocked;
            return true;
        }
        return false;
    }
}
