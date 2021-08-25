using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(FastSea2D))]
public class EditorFastSea2D : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        var obj = target as FastSea2D;
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("ForceRefresh")) {
                obj.ForceRefresh();
            }
            if (GUILayout.Button("Refresh")) {
                obj.Refresh();
            }
        }
        GUILayout.EndHorizontal();
    }
}
