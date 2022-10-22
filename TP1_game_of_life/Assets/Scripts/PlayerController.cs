using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject obj;

    GameObject[,] array_of_cubes = new GameObject[500, 500];

    List<string> visible_cubes = new List<string>();

    List<string> invisible_cubes = new List<string>();

    void Start()
    {
        instantiate_obj();
    }

    void Update()
    {
        search_cubes_to_change();

        set_cubes_state();
    }

    void search_cubes_to_change()
    {
        visible_cubes.Clear();

        invisible_cubes.Clear();

        for (int z = 0; z < 500; z++)
        {
            for (int i = 0; i < 500; i++)
            {
                if (array_of_cubes[z, i].activeInHierarchy == true)
                {
                    int soma = check_neighborhood(z, i);

                    if (soma < 2 || soma > 3)
                    {
                        invisible_cubes.Add(z.ToString() + "-" + i.ToString());
                    }
                }
                else
                {
                    int soma = check_neighborhood(z, i);

                    if (soma == 3)
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
        int soma = 0;

        if (z < 499 && i > 0 && i < 499 && z > 0)
        {
            if (array_of_cubes[z + 1, i - 1].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z + 1, i].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z + 1, i + 1].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z, i - 1].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z, i + 1].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z - 1, i - 1].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z - 1, i].activeInHierarchy == true)
            {
                soma++;
            }

            if (array_of_cubes[z - 1, i + 1].activeInHierarchy == true)
            {
                soma++;
            }
        }

        return soma;
    }

    void instantiate_obj()
    {
        for (int z = 0; z < 500; z++)
        {
            for (int i = 0; i < 500; i++)
            {
                float metadeZ = (transform.localScale.z * 10) - ((transform.localScale.z * 10) / 2);

                Vector3 poss = new Vector3(
                    transform.position.x + 499 - 1 * i,
                    transform.position.y,
                    transform.position.z - 1 + metadeZ - (1 * z)
                );

                GameObject novoBloco = Instantiate(obj, poss, Quaternion.identity);

                array_of_cubes[z, i] = novoBloco;

                novoBloco.name = z.ToString() + " - " + i.ToString();

                novoBloco.SetActive(false);
            }
        }
    }
}
