using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathManager))]
public class PathManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PathManager pathManager = (PathManager)target;
        
        if (GUILayout.Button("Generate Path"))
        {
            pathManager.GeneratePath();
        }

        if (GUILayout.Button("Fill List"))
        {
            pathManager.FillList();
        }
    }
}
