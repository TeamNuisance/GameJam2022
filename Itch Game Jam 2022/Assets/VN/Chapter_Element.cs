using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Chapter_Element", order = 1)]
public class Chapter_Element: ScriptableObject
{
    [SerializeField] string chapter_Title;
    [SerializeField] VN_Element[] VN_Array;

    public VN_Element GetPage(int a)
    {
        return VN_Array[a];
    }
    public string GetChapterTitle()
    {
        return chapter_Title;
    }



}
