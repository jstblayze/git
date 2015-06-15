//Author : Amina Khalique
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InteractableObject : MonoBehaviour 
{
    public GameObject InteractablePrompt;
    public Enums.Interactable ObjectType;
    public void PerformAppropriateBehavior()
    {
        switch(ObjectType)
        {
            default:
                Debug.Log("InteractableObject.cs - Something went wrong");
                break;

            case Enums.Interactable.CardReader:
                gameObject.GetComponent<CardReader>().Door.UnlockDoor();
                // Card Reader Sound Beep/ Card Reader Unlock door animation?

                break;
            case Enums.Interactable.Door:
                if(gameObject.GetComponent<Door>().DoorType == Enums.DoorType.CardReaderDoor)  // Card Reader Door
                {
                    if(gameObject.GetComponent<Door>().DoorState == Enums.DoorState.Locked) // Door that reader is attached to is Locked
                    {
                        InteractablePrompt.GetComponentInChildren<Text>().text = "Key Card Required!";
                    }
                    else if(gameObject.GetComponent<Door>().DoorState == Enums.DoorState.Unlocked) // Unlocked
                    {
                        gameObject.GetComponent<Door>().ActivateDoor();
                    }
                }
                else if(gameObject.GetComponent<Door>().DoorType == Enums.DoorType.Regular) // Regular Door
                {
                    if (gameObject.GetComponent<Door>().DoorState == Enums.DoorState.Locked) // Door is locked
                    {
                        if (gameObject.GetComponent<Door>().UnlockDoor())
                        {
                            gameObject.GetComponent<Door>().ActivateDoor();
                            // Open Door Animation Start
                        }
                        else
                        {
                            InteractablePrompt.GetComponentInChildren<Text>().text = "This door is locked!";
                        }
                    }
                    else // Door is unlocked
                    {
                        gameObject.GetComponent<Door>().ActivateDoor();
                        // Open Door Animation Start
                    }
                }
                break;

            case Enums.Interactable.Computer:
                InteractablePrompt.GetComponentInChildren<Text>().text = "Performed Interact Computer";
                // Computer Screen animation?
                break;
        }
    }
    public void TogglePlayerInInteractingRange(bool InRange)
    {
        if(InRange)
        {
            ZoneManager.InteractableIsInRange = true;
            ZoneManager.InteractableObjectInRange = this;
            InteractablePrompt.SetActive(true);
            switch (ObjectType)
            {
                default:
                    Debug.Log("InteractableObject.cs - Something went wrong");
                    break;
                case Enums.Interactable.Door:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "Open Door";
                    break;
                case Enums.Interactable.CardReader:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "Unlock CardReader";
                    break;
                case Enums.Interactable.SciFiDoor:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "Open SciFiDoor";
                    break;
                case Enums.Interactable.Computer:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "Interact Computer";
                    break;
            }
        }
        else
        {
            ZoneManager.InteractableIsInRange = false;
            ZoneManager.InteractableObjectInRange = null;
            InteractablePrompt.SetActive(true);
            switch (ObjectType)
            {
                default:
                    Debug.Log("InteractableObject.cs - Something went wrong");
                    break;
                case Enums.Interactable.CardReader:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "";
                    break;
                case Enums.Interactable.Door:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "";
                    break;
                case Enums.Interactable.SciFiDoor:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "";
                    break;
                case Enums.Interactable.Computer:
                    InteractablePrompt.GetComponentInChildren<Text>().text = "";
                    break;
            }
            InteractablePrompt.SetActive(false);
        }
    }
}