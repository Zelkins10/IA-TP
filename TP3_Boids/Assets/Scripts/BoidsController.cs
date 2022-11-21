using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    private AddBoids add_boids;
    private BoidsDestination boids_destination;
    private BoidsCenterOfMass boids_center_of_mass;
    private BoidsReduceDistance boids_reduce_distance;
    private BoidsMatchVelocity boids_match_velocity;
    private BoidsLimitVelocity boids_limit_velocity;

    void Start()
    {
        velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        boids_destination = GetComponent<BoidsDestination>();
        boids_center_of_mass = GetComponent<BoidsCenterOfMass>();
        boids_reduce_distance = GetComponent<BoidsReduceDistance>();
        boids_match_velocity = GetComponent<BoidsMatchVelocity>();
        boids_limit_velocity = GetComponent<BoidsLimitVelocity>();
    }

    void CalculateVelocity(Vector2 Vdes, Vector2 Vcen, Vector2 Vred, Vector2 Vmat)
    {
        velocity += Vdes + Vcen + Vred + Vmat;
    }

    void Update()
    {
        Vector2 Vdes = boids_destination.Destination();
        Vector2 Vcen = boids_center_of_mass.CenterOfMass();
        Vector2 Vred = boids_reduce_distance.ReduceDistance();
        Vector2 Vmat = boids_match_velocity.MatchVelocity();

        CalculateVelocity(Vdes, Vcen, Vred, Vmat);

        boids_limit_velocity.LimitVelocity();

        transform.LookAt(
            new Vector3(
                transform.position.x + velocity.x,
                transform.position.y,
                transform.position.z + velocity.y
            )
        );
        transform.position += new Vector3(velocity.x, transform.position.y, velocity.y) / 100;
    }
}
