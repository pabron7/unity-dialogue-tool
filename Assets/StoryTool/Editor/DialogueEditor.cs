using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueEditor : EditorWindow
{


    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    List<DialogueEntry> dialogueFirst;
    

    [MenuItem("Window/ Dialogue Editor")]

    public static void ShowWindow()
    {
        GetWindow<DialogueEditor>("Dialogue Editor");

    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();
 
        
    }
}
