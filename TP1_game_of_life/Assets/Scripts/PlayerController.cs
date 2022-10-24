using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject obj;

    public GameObject[,] array_of_cubes = new GameObject[50, 50];

    List<string> visible_cubes = new List<string>();

    List<string> invisible_cubes = new List<string>();

    void Start()
    {
        Application.targetFrameRate = 1;
        Physics.queriesHitTriggers = true;
        instantiate_obj();
    }

    void FixedUpdate()
    {
        search_cubes_to_change();

        set_cubes_state();
    }

    public void disactivate_cube(int z, int i)
    {
        array_of_cubes[z, i].SetActive(false);
    }

    void search_cubes_to_change()
    {
        visible_cubes.Clear();

        invisible_cubes.Clear();

        for (int z = 0; z < 50; z++)
        {
            for (int i = 0; i < 50; i++)
            {
                if (array_of_cubes[z, i].activeInHierarchy == true)
                {
                    int nb_of_neighbors = check_neighborhood(z, i);

                    if (nb_of_neighbors < 2 || nb_of_neighbors > 3)
                    {
                        invisible_cubes.Add(z.ToString() + "-" + i.ToString());
                    }
                }
                else
                {
                    int nb_of_neighbors = check_neighborhood(z, i);

                    if (nb_of_neighbors == 3)
                    {
                        visible_cubes.Add(z.ToString() + "-" + i.ToString());
                    }
                }
            }
        }
    }

    void set_cubes_state()
    {
        for (int i = 0; i < invisible_cubes.Count; i++)
        {
            string[] v = invisible_cubes[i].Split('-');

            array_of_cubes[int.Parse(v[0]), int.Parse(v[1])].SetActive(false);
        }

        for (int i = 0; i < visible_cubes.Count; i++)
        {
            string[] d = visible_cubes[i].Split('-');

            array_of_cubes[int.Parse(d[0]), int.Parse(d[1])].SetActive(true);
        }
    }

    int check_neighborhood(int z, int i)
    {
        int nb_of_neighbors = 0;

        if (z < 49 && i > 0 && i < 49 && z > 0)
        {
            if (array_of_cubes[z + 1, i - 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z + 1, i].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z + 1, i + 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z, i - 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z, i + 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z - 1, i - 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z - 1, i].activeInHierarchy)
            {
                nb_of_neighbors++;
            }

            if (array_of_cubes[z - 1, i + 1].activeInHierarchy)
            {
                nb_of_neighbors++;
            }
        }

        return nb_of_neighbors;
    }

    void instantiate_obj()
    {
        for (int z = 0; z < 50; z++)
        {
            for (int i = 0; i < 50; i++)
            {
                float metadeZ = (transform.localScale.z * 10) - ((transform.localScale.z * 10) / 2);

                Vector3 poss = new Vector3(
                    transform.position.x + 49 - 1 * i,
                    transform.position.y,
                    transform.position.z - 1 + metadeZ - (1 * z)
                );

                GameObject new_cube = Instantiate(obj, poss, Quaternion.identity);

                Rigidbody currentRb = new_cube.AddComponent<Rigidbody>();
                currentRb.useGravity = false;

                array_of_cubes[z, i] = new_cube;

                new_cube.name = z.ToString() + " - " + i.ToString();

                ClickingTest clicking_test = new_cube.AddComponent<ClickingTest>();
                clicking_test.set_coord(this, z, i);

                new_cube.SetActive(false);
            }
        }
    }
}
