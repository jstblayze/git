//Author: Amina Khalique
using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static Vector3 SavedPosition;

    public static Enums.Character CharacterSelected;
    public static LootManager LootManager;

    public static AnimationManager AnimationManager;

    public static bool ObjectInLootingRange;
    public static LootableObject ObjectInLootRange;

    public static bool InteractableIsInRange;
    public static InteractableObject InteractableObjectInRange;

    public static bool PickableIsInRange;
    public static PickableObject PickableObjectInRange;

    public static GameManager GM;

    void Awake() // Runs before anything else and should only happen ONCE during a session
    {
        GM = this;
        LootManager = gameObject.GetComponent<LootManager>(); // Already attached
    }
    public void LoadScene(string SceneToLoad)
    {
        DontDestroyOnLoad(gameObject); // Will Keep All of GameManager Active
        Application.LoadLevel(SceneToLoad);
    }
    public void SetCharacterSelected(Enums.Character CharacterChosen)
    {
        CharacterSelected = CharacterChosen;
    }
    public void LoadFromSave() // A button should call this
    {
        SavedPosition = Vector3.zero;
    }
    public Vector3 GetSavedPosition()
    {
        return SavedPosition;
    }
}
