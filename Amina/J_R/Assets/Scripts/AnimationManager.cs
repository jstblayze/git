//Author: Amina Khalique
//>>>! Matthew Whitely you could probably benefit from something like this
using UnityEngine;
using System.Collections;
public class AnimationManager : MonoBehaviour 
{
    // public animations dragged into here 

    public void PlayRyleyAnimation(Enums.RyleyAnim Animation) // Should return an animation
    {
        // Initialize AnimationToReturn Variable
        switch(Animation)
        {
            default:
                Debug.LogError("AnimationManager.cs: Unable to find RyleyAnimation asked for");
                break;
            case Enums.RyleyAnim.RyleyClawSwipe:
                // AnimationToReturn = Ryley's Claw Swipe
                break;
            case Enums.RyleyAnim.RyleyDeath:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyFeralDeath:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyInjuryStagger:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyJumpForward:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyKnifeStab:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyPipeSwing:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyReminderSwing:
                // AnimationToReturn =
                break;
            case Enums.RyleyAnim.RyleyRun:
                // AnimationToReturn =
                break;
        }
        // return AnimationToReturn
    } 
    public void PlayEnemyAnimation(Enums.Enemy EnemyType, Enums.EAnimationType Type) // Should return an animation
    {
        // Intialize AnimationToReturn variable
        switch(EnemyType)
        {
            default:
                Debug.LogError("AnimationManager.cs: Could not find correct Enemy Type for Animation");
                break;
            case Enums.Enemy.Gecko:
                switch(Type)
                {
                    default:
                        Debug.LogError("AnimationManager.cs: Could not find correct Gecko Animation");
                        break;
                    case Enums.EAnimationType.Death:
                        //AnimationToReturn =  Enums.GeckoAnim.GeckoDeath;
                        break;
                    case Enums.EAnimationType.Attack:
                        break;
                    case Enums.EAnimationType.InjuryStagger:
                        break;
                }
                break;
            case Enums.Enemy.Tiger:
                break;
            case Enums.Enemy.Komodo:
                break;
        }
        // return AnimationToReturn
    }
}
