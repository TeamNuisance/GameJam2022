using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Book_Element", order = 1)]
public class Book_Element : ScriptableObject
{
    [SerializeField] string book_Title;
    [SerializeField] Chapter_Element[] Chapter_Array;

    public Chapter_Element GetChapterElement(int a) {
        return Chapter_Array[a];    
    }
    public string GetBookTitle()
    {
        return book_Title;
    }

}
