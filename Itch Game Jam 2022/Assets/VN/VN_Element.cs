using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VN_Element", order = 1)]
public class VN_Element : ScriptableObject
{
    public enum ElementType { Text, Choice };
    public enum EnterAnimation { EnterNone, EnterStageLeft, EnterStageRight };
    public enum ExitAnimation { ExitNone, ExitStageLeft, ExitStageRight };



    public string page_Title, title_Text, vn_Text;

    public ElementType elementType;

    public string[] choiceTextArray;
    public int[] choiceNextArray;
    public int defaultNextPage;

    public EnterAnimation[] enterAnimationArray;
    public ExitAnimation[] exitAnimationArray;

    public GameObject backgroundTriggerObject;


    public bool display_Text, display_Title, display_Actors, display_Background;

    public CharacterLibrarySO[] actorLibrary;
    public int[] actorSpriteLibrary;
    //public Sprite background_Image;
    public Material background_Image;

    public bool ShowText() { return display_Text;  }
    public bool ShowTitle() { return display_Title; }
    public bool ShowActors() { return display_Actors; }
    public bool ShowBackground() { return display_Background; }

    public CharacterLibrarySO[] GetActorLibrary() { return actorLibrary; }
    public int[] GetActorSpriteID() { return actorSpriteLibrary; }
    public Material GetBackground() { return background_Image;  }

    public string GetEnterAnimation(int a) { return enterAnimationArray[a].ToString(); }
    public string GetExitAnimation(int a) { return exitAnimationArray[a].ToString(); }

    public string GetTitleText() { return title_Text; }
    public string GetVNText() { return vn_Text; }

    public string GetElementType() { return elementType.ToString(); }
    
    public int GetDefaultNextPage() {         return defaultNextPage;      }
    public string[] GetChoiceText() { return choiceTextArray; }
    public string GetChoiceText(int a) { return choiceTextArray[a]; }
    public int[] GetChoiceNextPage() { return choiceNextArray; }
    public int GetChoiceNextPage(int a) { return choiceNextArray[a]; }

    public bool IsThereTriggerObject()
    {
        if (backgroundTriggerObject != null) { return true; }
        return false;
    }

    public GameObject GetBackgroundTriggerObject() { return backgroundTriggerObject; }

}

