using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public int number_of_boids;
    public float time_to_start;
    public float game_of_life_time_rate;
    private AddBoids add_boids;

    void Start()
    {
        add_boids = GetComponent<AddBoids>();
        InvokeRepeating("decide_life_and_death", time_to_start, game_of_life_time_rate);
    }

    void decide_life_and_death()
    {
        foreach (List<GameObject> list_of_boids in AddBoids.lists_of_boids)
        {
            foreach (GameObject boid in list_of_boids)
            {
                boid.GetComponent<AlgoGen>().search_best_correspondance();
            }
        }
        int index = 0;
        foreach (
            List<GameObject> list_of_boids_in_group in AddBoids.best_corresponding_boids.Values.ToList()
        )
        {
            if (
                (
                    list_of_boids_in_group.Count > number_of_boids / 10
                    || list_of_boids_in_group.Count == 1
                )
                && Random.Range(0, 2) == 1
            )
            {
                delete_old_boids(list_of_boids_in_group, index);
            }
            else if (
                list_of_boids_in_group.Count >= number_of_boids / 50
                && list_of_boids_in_group.Count < number_of_boids / 20
            )
            {
                add_new_boids(list_of_boids_in_group, index);
            }
            ++index;
        }
        AddBoids.best_corresponding_boids.Clear();
    }

    void delete_old_boids(List<GameObject> list_of_boids_in_group, int index)
    {
        if (index < AddBoids.best_corresponding_boids.Keys.ToList().Count)
        {
            GameObject boid_to_destroy = AddBoids.best_corresponding_boids.Keys.ToList()[index][2];

            foreach (List<GameObject> list_of_boids in AddBoids.lists_of_boids)
            {
                if (list_of_boids.Contains(boid_to_destroy))
                {
                    list_of_boids.Remove(boid_to_destroy);
                    list_of_boids_in_group.Remove(boid_to_destroy);
                }
            }
            Destroy(boid_to_destroy);
        }
    }

    void add_new_boids(List<GameObject> list_of_boids_in_group, int index)
    {
        Vector3 position = new Vector3();
        int number_of_boids_in_group = 0;
        foreach (GameObject boid in list_of_boids_in_group)
        {
            position += boid.transform.position;
            ++number_of_boids_in_group;
        }
        position /= number_of_boids_in_group;

        List<GameObject> list_of_boids = new List<GameObject>();
        foreach (List<GameObject> list in AddBoids.lists_of_boids)
        {
            if (list.Contains(list_of_boids_in_group[0]))
            {
                list_of_boids = list;
            }
        }

        // TODO : Have to test bc some times list_of_boids is empty.
        if (list_of_boids.ElementAtOrDefault(0) != default(GameObject))
        {
            // TODO : Just use the parent gameObject in instantiate to immediatly add component
            GameObject new_boid = Instantiate(
                list_of_boids[0].gameObject,
                new Vector3(position.x, 0f, position.z),
                Quaternion.identity
            );

            list_of_boids.Add(new_boid);
            List<GameObject> new_boids = new List<GameObject>();
            new_boids.Add(new_boid);

            add_boids.add_component_in_boids(new_boids);
            AlgoGen current_algogen = new_boid.GetComponent<AlgoGen>();
            GameObject first_parent = AddBoids.best_corresponding_boids.Keys.ToList()[index][0];
            GameObject other_parent = AddBoids.best_corresponding_boids.Keys.ToList()[index][1];
            if (Random.value > 0.5f)
            {
                current_algogen.temperature = first_parent.GetComponent<AlgoGen>().temperature;
                if (Random.value > 0.7f)
                {
                    current_algogen.temperature = Random.Range(-20.0f, 50.0f);
                }
            }
            else
            {
                current_algogen.temperature = other_parent.GetComponent<AlgoGen>().temperature;
                if (Random.value > 0.7f)
                {
                    current_algogen.temperature = Random.Range(-20.0f, 50.0f);
                }
            }

            if (Random.value > 0.5f)
            {
                current_algogen.altitude = first_parent.GetComponent<AlgoGen>().altitude;
                if (Random.value > 0.7f)
                {
                    current_algogen.altitude = Random.Range(0.0f, 3000.0f);
                }
            }
            else
            {
                current_algogen.altitude = other_parent.GetComponent<AlgoGen>().altitude;
                if (Random.value > 0.7f)
                {
                    current_algogen.altitude = Random.Range(0.0f, 3000.0f);
                }
            }

            if (Random.value > 0.5f)
            {
                current_algogen.humidity = first_parent.GetComponent<AlgoGen>().humidity;
                if (Random.value > 0.7f)
                {
                    current_algogen.humidity = Random.Range(0.0f, 100.0f);
                }
            }
            else
            {
                current_algogen.humidity = other_parent.GetComponent<AlgoGen>().humidity;
                if (Random.value > 0.7f)
                {
                    current_algogen.humidity = Random.Range(0.0f, 100.0f);
                }
            }
        }
    }
}
