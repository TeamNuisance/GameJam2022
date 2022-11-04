using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterLibrarySO", order = 1)]
public class CharacterLibrarySO : ScriptableObject
{

    [SerializeField] string characterName;
    [SerializeField] Sprite[] imageArray;

    public string GetName() {
        return characterName;
    }
    public Sprite GetImage(int a) {
        return imageArray[a];
    }
    public Sprite[] GetImage()
    {
        return imageArray;
    }
}
