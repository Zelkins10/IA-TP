using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public List<GameObject> list_of_boids;
    public float acceptance_radius = 100.0f;

    private AddBoids add_boids;
    private BoidsDestination boids_destination;
    private BoidsCenterOfMass boids_center_of_mass;
    private BoidsReduceDistance boids_reduce_distance;
    private BoidsMatchVelocity boids_match_velocity;
    private BoidsLimitVelocity boids_limit_velocity;

    void Start()
    {
        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        boids_destination = GetComponent<BoidsDestination>();
        boids_center_of_mass = GetComponent<BoidsCenterOfMass>();
        boids_reduce_distance = GetComponent<BoidsReduceDistance>();
        boids_match_velocity = GetComponent<BoidsMatchVelocity>();
        boids_limit_velocity = GetComponent<BoidsLimitVelocity>();
    }

    void CalculateVelocity(Vector2 Vdes, Vector2 Vcen, Vector2 Vred, Vector2 Vmat)
    {
        velocity += (Vdes + Vcen + Vred + Vmat);
    }

    void Update()
    {
        Vector2 Vdes = boids_destination.Destination();
        Vector2 Vcen = boids_center_of_mass.CenterOfMass();
        Vector2 Vred = boids_reduce_distance.ReduceDistance();
        Vector2 Vmat = boids_match_velocity.MatchVelocity();

        Vector3 destination_position = new Vector3(boids_destination.position.x, transform.position.y, boids_destination.position.y);

        CalculateVelocity(Vdes, Vcen, Vred, Vmat);

        boids_limit_velocity.LimitVelocity();

        int count = 0;
        foreach (GameObject boid in list_of_boids)
        {
            if (Vector3.Distance(destination_position, boid.transform.position) > acceptance_radius)
            {
                ++count;
            }
        }

        if (count < list_of_boids.Count / 10)
        {
            velocity = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }

        Vector3 target_position = new Vector3(
            transform.position.x + velocity.x,
            transform.position.y,
            transform.position.z + velocity.y
        );
        var targetRotation = Quaternion.LookRotation(target_position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);

        if (count < list_of_boids.Count / 10)
        {
            velocity = new Vector2(0.0f, 0.0f);
        }
        
        //transform.position += new Vector3(velocity.x, transform.position.y, velocity.y);
    }
}
