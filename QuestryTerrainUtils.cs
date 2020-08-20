using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using QUnity.Utility;

public static class QuestryTerrainUtils
{
    /// <summary>
    /// generates a heightmap from given greyscale texture.
    /// </summary>
    /// <param name="grayScaleTexture"> If the texture is smaller than heightmap, then the texture will get repeated over the heightmap. </param>
    /// <param name="heightMapResolution"> the resolution of the heightmap generated </param>
    /// <param name="scale"> how the height map will get scaled in each direction along the texture. set to Vector3.one for no scaling.</param>
    public static float[,] ConvertGrayScaleTextureToHeightMap(Texture2D grayScaleTexture, int heightMapResolution, Vector3 scale)
    {
        float[,] heightMap = new float[heightMapResolution, heightMapResolution];
        Color[] textureMap = grayScaleTexture.GetPixels(0, 0, Mathf.CeilToInt(heightMapResolution), Mathf.CeilToInt(heightMapResolution));

        for (int x = 0; x < heightMapResolution; x++)
        {
            for (int y = 0; y < heightMapResolution; y++)
            {
                heightMap[x, y] = textureMap[Mathf.CeilToInt((x * heightMapResolution * scale.x) + (y * scale.z)) % textureMap.Length].grayscale * scale.y;
            }
        }

        return heightMap;
    }
}