using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerPlace))]
public class TowerPlaceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TowerPlace towerPlace = (TowerPlace)target;

        EditorGUILayout.LabelField("Compatible Types", EditorStyles.boldLabel);
        if (towerPlace.compatibleTypes == null)
        {
            towerPlace.compatibleTypes = new SerializableDictionary<string, bool>();
        }

        foreach (var key in new List<string> { "MagicTower", "Windmill", "StoneWall" })
        {
            if (!towerPlace.compatibleTypes.ContainsKey(key))
            {
                towerPlace.compatibleTypes[key] = false;
            }

            towerPlace.compatibleTypes[key] = EditorGUILayout.Toggle(key, towerPlace.compatibleTypes[key]);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(towerPlace);
        }
    }
}
