using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using QUnity.Utility;

[ExecuteInEditMode]
public class QuestryTerrain : MonoBehaviour
{
    private Terrain modifiedTerrain;
    private TerrainData modifiedTerrainData;

    [SerializeField]
    private Texture2D heightMapImage;
    [SerializeField]
    private Vector3 heightMapScale = new Vector3(1, 1, 1);

    private void OnEnable()
    {
        modifiedTerrain = this.GetComponent<Terrain>();
        modifiedTerrainData = modifiedTerrain.terrainData;
    }

    private void Awake()
    {
        //Add tags
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

        QEditorUtility.AddTag(tagManager, "Terrain");

        gameObject.tag = "Terrain";
    }

    #region Image Loading and Exporting

    public void LoadHeightMapFromTexture()
    {
        modifiedTerrainData.SetHeights(0, 0, QuestryTerrainUtils.ConvertGrayScaleTextureToHeightMap(heightMapImage, modifiedTerrainData.heightmapResolution, heightMapScale));
    }

    #endregion

    public void ResetHeightMap()
    {
        modifiedTerrainData.SetHeights(0, 0, QuestryTerrainUtils.ConstructZeroHeightMap(modifiedTerrainData.heightmapResolution));
    }
}
