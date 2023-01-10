using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class HeatmapEditor : EditorWindow 
{

    HeatmapManager hm;
    Color color;

    [MenuItem("Window/Heatmap Editor")]
    static void OpenWindow() 
    {
        HeatmapEditor window = (HeatmapEditor)GetWindow<HeatmapEditor>();
        window.minSize = new Vector2(200, 400);
        window.titleContent = new GUIContent("Heatmap");
        window.Show();
    }

    private void OnEnable() 
    {
        //hm = FindObjectOfType<HeatmapEditor>();
    }

    private void OnGUI() 
    {
        DrawSettings();
    }
    
    private void DrawSettings()
    {
        // EditorGUI.EnumPopup

        // EditorGUILayout.BeginHorizontal();
        // GUILayout.Label("Search radius");
        // hm.searchRadius = EditorGUILayout.FloatField(hm.maxSearchRadius);
        // EditorGUILayout.EndHorizontal();
        // GUILayout.BeginHorizontal();
        // color = EditorGUILayout.ColorField("New Color, color");
    }

}

