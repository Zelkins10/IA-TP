using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlgoGen : MonoBehaviour
{
    public float acceptance_radius = 100.0f;
    public float temperature;
    public float altitude;
    public float humidity;
    public GameObject current_terrain;
    public float compatibility = 0.0f;
    private BoidsController this_controller;
    public List<GameObject> list_of_boids;

    void Start()
    {
        list_of_boids = AddBoids.lists_of_boids[
            (int)gameObject.GetComponent<BoidsController>().boid_type
        ];
        this_controller = GetComponent<BoidsController>();
        if (temperature == default(float))
        {
            temperature = Random.Range(-20, 50);
            altitude = Random.Range(0, 3000);
            humidity = Random.Range(0, 100);
        }
    }

    void Update()
    {
        if (
            Physics.Raycast(
                transform.position + new Vector3(0f, 5f, 0f),
                Vector3.down * 10f,
                out RaycastHit hit_info
            )
        )
        {
            if (hit_info.collider.gameObject != null)
            {
                if (hit_info.collider.gameObject.tag == "Mountain")
                {
                    current_terrain = hit_info.collider.gameObject;
                }
                else if (hit_info.collider.gameObject.transform.parent != null)
                {
                    current_terrain = hit_info.collider.gameObject.transform.parent.gameObject;
                }

                if (current_terrain != null)
                {
                    EnvironmentParameters environment_parameters =
                        current_terrain.GetComponent<EnvironmentParameters>();
                    compatibility = 0.0f;
                    compatibility +=
                        Mathf.Abs(environment_parameters.temperature - temperature)
                        / (50.0f - (-20.0f)); // TODO : need to be automatised
                    compatibility +=
                        Mathf.Abs(environment_parameters.altitude - altitude) / (3000.0f - 0.0f); // need to be automatised
                    compatibility +=
                        Mathf.Abs(environment_parameters.humidity - humidity) / (100.0f - 0.0f); // need to be automatised
                    compatibility /= 3.0f;
                }
            }
        }
    }

    public void search_best_correspondance()
    {
        float max_compatibility = compatibility;
        float second_compatibility = 0.0f;
        float min_compatibility = compatibility;
        int current_id = list_of_boids.IndexOf(gameObject);
        int max_id = current_id;
        int second_id = current_id;
        int min_id = current_id;
        int index = 0;
        List<GameObject> list_of_boids_in_group = new List<GameObject>();
        list_of_boids_in_group.Add(gameObject);
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != gameObject)
            {
                if (
                    Vector3.Distance(transform.position, boid.transform.position)
                    <= acceptance_radius
                )
                {
                    AlgoGen current_algogen = boid.GetComponent<AlgoGen>();
                    list_of_boids_in_group.Add(boid);
                    float current_compatibility = current_algogen.compatibility;
                    if (current_compatibility < min_compatibility)
                    {
                        min_id = index;
                        min_compatibility = current_compatibility;
                    }
                    if (max_compatibility < current_compatibility)
                    {
                        second_id = max_id; // le premier devient le second.
                        second_compatibility = max_compatibility;
                        max_id = index;
                        max_compatibility = current_compatibility;
                    }
                    else if (second_compatibility < current_compatibility)
                    {
                        second_id = index;
                        second_compatibility = current_compatibility;
                    }
                }
            }
            ++index;
        }

        // TODO : Tester si deux listes identiques renvoient vrai.
        List<GameObject> current_couple = new List<GameObject>();
        current_couple.Add(list_of_boids[max_id]);
        current_couple.Add(list_of_boids[second_id]);
        current_couple.Add(list_of_boids[min_id]);
        if (AddBoids.best_corresponding_boids.Count == 0)
        {
            AddBoids.best_corresponding_boids.Add(current_couple, list_of_boids_in_group);
        }
        else
        {
            bool not_exist = true;
            foreach (List<GameObject> couple in AddBoids.best_corresponding_boids.Keys.ToList())
            {
                if (couple == current_couple)
                {
                    not_exist = false;
                }
            }
            if (not_exist)
            {
                AddBoids.best_corresponding_boids.Add(current_couple, list_of_boids_in_group);
            }
        }
    }
}
