using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFractals : MonoBehaviour
{
    public Terrain main;
    public float smooth;
    public float add_random;

    void Start()
    {
        int res = main.terrainData.heightmapResolution;
        int max = res - 1;

        float[,] heights = main.terrainData.GetHeights(0, 0, res, res);

        for (int i = 0; i < res; i++)
        {
            for (int j = 0; j < res; j++)
            {
                heights[i, j] = 0;
            }
        }

        heights[0, 0] = Random.Range(-add_random, add_random);
        heights[0, max] = Random.Range(-add_random, add_random);
        heights[max, 0] = Random.Range(-add_random, add_random);
        heights[max, max] = Random.Range(-add_random, add_random);

        int index = max;
        int count = 1;

        while (index > 1)
        {
            /// Diamant :
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int minX = i * index;
                    int minY = j * index;
                    int maxX = minX + index;
                    int maxY = minY + index;
                    heights[index / 2 + minX, index / 2 + minY] =
                        (
                            heights[minX, minY]
                            + heights[minX, maxY]
                            + heights[maxX, minY]
                            + heights[maxX, maxY]
                        ) / 4
                        + Random.Range(-index / 2, index / 2) * smooth;
                }
            }

            /// Carré :
            int margin = 0;
            for (int i = 0; i <= max; i += index / 2)
            {
                if (margin == 0)
                {
                    margin = index / 2;
                }
                else
                {
                    margin = 0;
                }
                for (int j = margin; j <= max; j += index)
                {
                    float sum = 0;
                    int number_of_neighbors = 0;
                    if (i - index / 2 >= 0) // Top
                    {
                        sum += heights[i - index / 2, j];
                        ++number_of_neighbors;
                    }
                    if (i + index / 2 <= max) // Bottom
                    {
                        sum += heights[i + index / 2, j];
                        ++number_of_neighbors;
                    }
                    if (j - index / 2 >= 0) // Left
                    {
                        sum += heights[i, j - index / 2];
                        ++number_of_neighbors;
                    }
                    if (j + index / 2 <= max) // Right
                    {
                        sum += heights[i, j + index / 2];
                        ++number_of_neighbors;
                    }
                    heights[i, j] =
                        sum / number_of_neighbors + Random.Range(-index / 2, index / 2) * smooth;
                }
            }
            count *= 2;
            index /= 2;
        }

        /// Print all the heights of the map.
        // for (int i = 0; i < res; i++)
        // {
        //     for (int j = 0; j < res; j++)
        //     {
        //         Debug.Log("[" + i + ", " + j + "]" + heights[i, j]);
        //     }
        // }

        main.terrainData.SetHeights(0, 0, heights);
    }
}
