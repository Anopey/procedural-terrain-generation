using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestryTerrain)), CanEditMultipleObjects]
public class QuestryTerrainEditor : Editor
{


    private void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        QuestryTerrain questryTerrain = (QuestryTerrain)target;

        

        serializedObject.ApplyModifiedProperties();
    }

}
