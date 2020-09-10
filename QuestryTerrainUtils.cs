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
    /// <param name="texture"> If the texture * scale is smaller than heightmap, then the texture will get repeated over the heightmap. </param>
    /// <param name="heightMapResolution"> the resolution of the heightmap generated </param>
    /// <param name="scale"> how the height map will get scaled in each direction along the texture. set to Vector3.one for no scaling.</param>
    public static float[,] ConvertGrayScaleTextureToHeightMap(Texture2D texture, int heightMapResolution, Vector3 scale)
    {
        float[,] heightMap = new float[heightMapResolution, heightMapResolution];
        Color[] colorMap = texture.GetPixels(0,0, Math.Min((int)(heightMapResolution * scale.x), texture.width) , Math.Min((int)(heightMapResolution * scale.y), texture.height));
        for (int y = 0; y < heightMapResolution; y++)
        {
            for (int x = 0; x < heightMapResolution; x++)
            {
                heightMap[y, x] = colorMap[(int)(y * heightMapResolution * scale.y + x * scale.x)].grayscale;
            }
        }

        return heightMap;
    }


    public static float[,] ConstructZeroHeightMap(int resolution)
    {
        float[,] heightMap = new float[resolution, resolution];

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                heightMap[x, y] = 0;
            }
        }

        return heightMap;
    }
}