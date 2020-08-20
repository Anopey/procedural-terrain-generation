using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using QUnity.Utility;

[ExecuteInEditMode]
public class QuestryTerrain : MonoBehaviour
{

    private void Awake()
    {
        //Add tags
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

        QEditorUtility.AddTag(tagManager, "Terrain");

        gameObject.tag = "Terrain";
    }

}
