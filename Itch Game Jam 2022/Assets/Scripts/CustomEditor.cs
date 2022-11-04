using UnityEngine;
using UnityEditor;
using System.Collections;

public class CustomEditor : EditorWindow

{
    [MenuItem("Window/CustomEditor")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomEditor));
    }

    void OnGUI()
    {
        // The actual window code goes here
    }
}