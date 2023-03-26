using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;

public class WFC : MonoBehaviour
{
    private WFC_Datas datas;
    public int size_x = 40;
    public int size_z = 40;

    void Awake()
    {
        // Datas initialisation :
        datas = GetComponent<WFC_Datas>();
        WFC_Grid_element[,] grid = new WFC_Grid_element[size_x, size_z];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = new WFC_Grid_element()
                {
                    possible_terrains = new List<int>(),
                    list_of_neighbors = new Dictionary<int, WFC_Grid_element>()
                };
                if (i > 11 && i < 28 && j > 11 && j < 28)
                {
                    grid[i, j].value = -2;
                }
                else
                {
                    for (int k = 0; k < datas.list_of_terrains.Count; k++)
                    {
                        grid[i, j].possible_terrains.Add(k);
                    }
                }
            }
        }

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                WFC_Grid_element grid_element = grid[i, j];
                // Left neighbor
                if (j - 1 >= 0)
                {
                    grid_element.list_of_neighbors.Add(0, grid[i, j - 1]);
                }
                // Top neighbor
                if (i - 1 >= 0)
                {
                    grid_element.list_of_neighbors.Add(1, grid[i - 1, j]);
                }
                // Right neighbor
                if (j + 1 < grid.GetLength(1))
                {
                    grid_element.list_of_neighbors.Add(2, grid[i, j + 1]);
                }
                // Bottom neighbor
                if (i + 1 < grid.GetLength(0))
                {
                    grid_element.list_of_neighbors.Add(3, grid[i + 1, j]);
                }
            }
        }

        int number_of_element_in_grid = grid.GetLength(0) * grid.GetLength(1);
        int count = 0;
        while (count < number_of_element_in_grid)
        {
            int[,] emptyCells = new int[number_of_element_in_grid, 2];
            int emptyCount = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].value == -1)
                    {
                        emptyCells[emptyCount, 0] = i;
                        emptyCells[emptyCount, 1] = j;
                        emptyCount++;
                    }
                }
            }

            int randomIndex = Random.Range(0, emptyCount);
            int current_i = emptyCells[randomIndex, 0];
            int current_j = emptyCells[randomIndex, 1];
            WFC_Grid_element current_grid_element = grid[current_i, current_j];

            Debug.Log("---------------------");
            Debug.Log("i = " + current_i + " / j = " + current_j);

            foreach (var neighbor in current_grid_element.list_of_neighbors)
            {
                Debug.Log(neighbor.Key);
                if (neighbor.Value.value != -1)
                {
                    Debug.Log("Value = " + neighbor.Value.value);
                }
                else
                {
                    Debug.Log("List of possible terrains : ");
                    foreach (var possible_terrain in neighbor.Value.possible_terrains)
                    {
                        Debug.Log("     - " + possible_terrain);
                    }
                }
            }
            Debug.Log("---------------------");

            if (current_grid_element.possible_terrains.Count == 0)
            {
                Debug.Log("<!><!><!><!><!><!><!><!><!><!>");
                Debug.Log("i = " + current_i + " / j = " + current_j);
                current_grid_element.value = -2;
                Debug.Log("<!><!><!><!><!><!><!><!><!><!>");
            }
            else
            {
                current_grid_element.value = current_grid_element.possible_terrains[
                    Random.Range(0, current_grid_element.possible_terrains.Count)
                ];
            }

            ++count;

            // Check all possible tiles and their compatibility with neighbors
            count += UpdateCompatibility(current_grid_element);
        }

        // Render terrains
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j].value != -2)
                {
                    GameObject gameObject = datas.list_of_terrains[grid[i, j].value].terrain;
                    if (gameObject != null)
                    {
                        Vector3 position = new Vector3(
                            62.5F * (grid.GetLength(1) - 1) + 125.0f * -j,
                            0.0f,
                            -62.5F * (grid.GetLength(0) - 1) + 125.0f * i
                        );
                        GameObject new_terrain = Instantiate(
                            gameObject,
                            position,
                            Quaternion.identity
                        );
                        new_terrain.transform.localScale = new Vector3(25.0f, 25.0f, 25.0f);
                        EnvironmentParameters environment =
                            new_terrain.AddComponent<EnvironmentParameters>();
                        EnvironmentParameters other_environment = datas.list_of_terrains[
                            grid[i, j].value
                        ].environment;
                        environment.temperature = other_environment.temperature;
                        environment.humidity = other_environment.humidity;
                        environment.altitude = other_environment.altitude;

                        GameObject child_object;
                        if (new_terrain.transform.Find("Plane") == null)
                        {
                            Debug.Log("test");
                            child_object = new_terrain.transform.Find("Plane.001").gameObject;
                        }
                        else
                        {
                            child_object = new_terrain.transform.Find("Plane").gameObject;
                        }
                        MeshCollider meshCollider = child_object.AddComponent<MeshCollider>();
                    }
                }
            }
        }
        GameObject.Find("NavMesh").GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    int UpdateCompatibility(WFC_Grid_element grid_element)
    {
        int count = 0;

        // Boucle qui parcourt tous les voisins en commençant vers la gauche et en finissant par le bas.
        foreach (KeyValuePair<int, WFC_Grid_element> neighbor in grid_element.list_of_neighbors)
        {
            bool is_modified = false;

            if (
                neighbor.Value.possible_terrains.Count == 0
                || neighbor.Value.value != -1
                || neighbor.Value != grid_element
            )
            {
                continue;
            }
            List<int> possibleTerrainsCopy = new List<int>(neighbor.Value.possible_terrains);

            // Boucle qui parcourt tous les terrains possibles du voisin courant.
            for (int i = possibleTerrainsCopy.Count - 1; i >= 0; i--)
            {
                int index = possibleTerrainsCopy[i];
                WFC_Terrain terrain = datas.list_of_terrains[index];

                if (grid_element.value == -1)
                {
                    bool have_compatibility = false;
                    foreach (int possible_terrain_id in grid_element.possible_terrains)
                    {
                        if (
                            terrain.list_of_edges[(neighbor.Key + 2) % 4]
                            == datas.list_of_terrains[possible_terrain_id].list_of_edges[
                                neighbor.Key
                            ]
                        )
                        {
                            have_compatibility = true;
                            break;
                        }
                    }
                    if (!have_compatibility)
                    {
                        is_modified = true;
                        neighbor.Value.possible_terrains.Remove(index);
                    }
                }
                else if (
                    terrain.list_of_edges[(neighbor.Key + 2) % 4]
                    != datas.list_of_terrains[grid_element.value].list_of_edges[neighbor.Key]
                )
                {
                    is_modified = true;
                    neighbor.Value.possible_terrains.Remove(index);
                }
            }

            if (neighbor.Value.possible_terrains.Count == 1)
            {
                neighbor.Value.value = neighbor.Value.possible_terrains[0];
                ++count;
            }
            if (is_modified)
            {
                count += UpdateCompatibility(neighbor.Value);
            }
        }
        return count;
    }
}
