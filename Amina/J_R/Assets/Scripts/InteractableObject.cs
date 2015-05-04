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
                InteractablePrompt.GetComponentInChildren<Text>().text = "Performed CardReader Interaction";
                // Card Reader Sound Beep/ Card Reader Unlock door animation?
                break;
            case Enums.Interactable.Door:
                InteractablePrompt.GetComponentInChildren<Text>().text = "Performed Open Door";
                // Open Door Animation Start
                break;
            case Enums.Interactable.SciFiDoor:
                InteractablePrompt.GetComponentInChildren<Text>().text = "Performed Open SciFiDoor";
                // Open SciFi Door Animation Start
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
            GameManager.InteractableIsInRange = true;
            GameManager.InteractableObjectInRange = this;
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
            GameManager.InteractableIsInRange = false;
            GameManager.InteractableObjectInRange = null;
            InteractablePrompt.SetActive(true);
            switch (ObjectType)
            {
                default:
                    Debug.Log("InteractableObject.cs - Something went wrong");
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