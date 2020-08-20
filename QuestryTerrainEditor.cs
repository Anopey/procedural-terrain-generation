using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestryTerrain)), CanEditMultipleObjects]
public class QuestryTerrainEditor : Editor
{

    SerializedProperty heightMapScale, heightMapImage;

    //foldouts
    bool foldShowImportExportTexture;

    private void OnEnable()
    {
        heightMapScale = serializedObject.FindProperty("heightMapScale");
        heightMapImage = serializedObject.FindProperty("heightMapImage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        QuestryTerrain questryTerrain = (QuestryTerrain)target;

        foldShowImportExportTexture = EditorGUILayout.Foldout(foldShowImportExportTexture, "Import/Export Texture");
        if (foldShowImportExportTexture)
        {
            GUILayout.Label("Import Heights From GreyScale Texture", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(heightMapImage);
            EditorGUILayout.PropertyField(heightMapScale);
            if(GUILayout.Button("Load Texture"))
            {
                questryTerrain.LoadHeightMapFromTexture();
            }

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);


        }

        serializedObject.ApplyModifiedProperties();
    }

}
