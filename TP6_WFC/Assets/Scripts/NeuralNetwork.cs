using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    public float first_entry = 0.0f;
    public float second_entry = 0.0f;
    public float first_weight = 1.0f;
    public float second_weight = 1.0f;
    public float Uk = 0.0f;
    public float threshold = 0.0f;
    public int Yk = 0;
    public Vector2 VFight = new Vector2();

    public List<GameObject> group = new List<GameObject>();
    public float acceptance_radius = 100.0f;
    public int number_of_allies = 0;
    public int number_of_enemies = 0;
    public GameObject nearest_enemy;
    public float nearest_enemy_distance = 0.0f;
    public float average_allies_compatibility = 0.0f;
    public float average_enemies_compatibility = 0.0f;

    void Start()
    {
        nearest_enemy_distance = acceptance_radius + 1.0f;
        InvokeRepeating("search_allies", 0.0f, 1.0f);
        InvokeRepeating("search_enemies", 0.0f, 1.0f);
    }

    void search_allies()
    {
        foreach (
            List<GameObject> list_of_boids_in_group in AddBoids.best_corresponding_boids.Values.ToList()
        )
        {
            if (
                list_of_boids_in_group.Contains(gameObject)
                && list_of_boids_in_group.Count > number_of_allies
            )
            {
                number_of_allies = list_of_boids_in_group.Count();
            }
        }
    }

    void search_enemies()
    {
        number_of_enemies = 0;
        number_of_allies = 0;
        average_allies_compatibility = 0.0f;
        average_enemies_compatibility = 0.0f;

        foreach (List<GameObject> list_of_boids in AddBoids.lists_of_boids)
        {
            if (
                list_of_boids
                == AddBoids.lists_of_boids[
                    (int)gameObject.GetComponent<BoidsController>().boid_type
                ]
            )
            {
                foreach (GameObject boid in list_of_boids)
                {
                    if (
                        boid != null
                        && boid != gameObject
                        && Vector3.Distance(transform.position, boid.transform.position)
                            <= acceptance_radius
                    )
                    {
                        ++number_of_allies;
                        average_allies_compatibility += boid.GetComponent<AlgoGen>().compatibility;
                    }
                }
                if (number_of_allies > 0)
                {
                    average_allies_compatibility /= number_of_allies;
                }
                break;
            }
            foreach (GameObject boid in list_of_boids)
            {
                if (
                    Vector3.Distance(transform.position, boid.transform.position)
                    <= acceptance_radius
                )
                {
                    ++number_of_enemies;
                    if (
                        boid != null
                        && Vector3.Distance(boid.transform.position, transform.position)
                            < nearest_enemy_distance
                    )
                    {
                        nearest_enemy = boid;
                    }
                    average_enemies_compatibility += boid.GetComponent<AlgoGen>().compatibility;
                }
            }
            if (number_of_enemies > 0)
            {
                average_enemies_compatibility /= number_of_enemies;
            }
        }
    }

    void Update() // TODO : Give force of movement only for some seconds and not infinitly ?
    {
        if (nearest_enemy == null)
        {
            VFight = new Vector2(0.0f, 0.0f);
            return;
        }

        NeuralNetwork enemy_neural_network = nearest_enemy.GetComponent<NeuralNetwork>();

        first_entry = number_of_allies - enemy_neural_network.number_of_allies;
        first_entry /= AddBoids.number_of_boids;

        second_entry = average_allies_compatibility - average_enemies_compatibility;

        Uk = first_entry * first_weight + second_entry * second_weight;
        if (Uk >= 0)
        {
            Yk = 1;
            VFight = new Vector2(
                nearest_enemy.transform.position.x - transform.position.x,
                nearest_enemy.transform.position.z - transform.position.z
            );
        }
        else
        {
            Yk = 0;
            VFight = new Vector2(
                transform.position.x - nearest_enemy.transform.position.x,
                transform.position.z - nearest_enemy.transform.position.z
            );
        }
    }
}
