using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoids : MonoBehaviour
{
    public Camera cam;
    public GameObject child_object;
    public List<GameObject> children;
    public int number_of_boids = 12;
    public int vlim = 10;
    public int distance_min = 5;

    void Start()
    {
        for (int i = 0; i < number_of_boids; i++)
        {
            GameObject new_character = Instantiate(
                child_object,
                new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)),
                Quaternion.identity
            );
            new_character.name = i.ToString();
            new_character.AddComponent<UnityEngine.AI.NavMeshAgent>();
            children.Add(new_character);
        }
        foreach (GameObject child in children)
        {
            BoidsController controller = child.AddComponent<BoidsController>();

            BoidsDestination destination = child.AddComponent<BoidsDestination>();
            destination.cam = cam;
            destination.this_boid = child;

            BoidsCenterOfMass center_of_mass = child.AddComponent<BoidsCenterOfMass>();
            center_of_mass.list_of_boids = children;
            center_of_mass.this_boid = child;

            BoidsReduceDistance reduce_distance = child.AddComponent<BoidsReduceDistance>();
            reduce_distance.list_of_boids = children;
            reduce_distance.this_boid = child;
            reduce_distance.distance_min = distance_min;

            BoidsMatchVelocity match_velocity = child.AddComponent<BoidsMatchVelocity>();
            match_velocity.list_of_boids = children;
            match_velocity.this_boid = child;

            BoidsLimitVelocity limit_velocity = child.AddComponent<BoidsLimitVelocity>();
            limit_velocity.this_boid = child;
            limit_velocity.vlim = vlim;
        }
    }
}
