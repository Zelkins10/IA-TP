using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static BoidType;

public class BoidsController : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public Terrain corresponding_terrain;
    public Vector3 position;
    public BoidType boid_type;

    private BoidsDestination boids_destination;
    private BoidsCenterOfMass boids_center_of_mass;
    private BoidsReduceDistance boids_reduce_distance;
    private BoidsMatchVelocity boids_match_velocity;
    private BoidsLimitVelocity boids_limit_velocity;

    void Awake()
    {
        corresponding_terrain = AddBoids.GetClosestCurrentTerrain(transform.position);
    }

    void Start()
    {
        velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        boids_destination = GetComponent<BoidsDestination>();
        boids_center_of_mass = GetComponent<BoidsCenterOfMass>();
        boids_reduce_distance = GetComponent<BoidsReduceDistance>();
        boids_match_velocity = GetComponent<BoidsMatchVelocity>();
        boids_limit_velocity = GetComponent<BoidsLimitVelocity>();
    }

    void CalculateVelocity(Vector2 Vdes, Vector2 Vcen, Vector2 Vred, Vector2 Vmat, Vector2 VFight)
    {
        velocity += (
            Vdes / Terrain.activeTerrain.terrainData.size.x * 5.0f
            + Vcen / Terrain.activeTerrain.terrainData.size.z * 5.0f
            + Vred * 5.0f
            + Vmat * 5.0f
            + VFight * 10.0f // TODO : Find the good value, 50 is too much maybe ? 
        );
    }

    void FixedUpdate()
    {
        position = transform.position;
        Vector2 Vdes = boids_destination.Destination();
        Vector2 Vcen = boids_center_of_mass.CenterOfMass();
        Vector2 Vred = boids_reduce_distance.ReduceDistance();
        Vector2 Vmat = boids_match_velocity.MatchVelocity();
        Vector2 VFight = gameObject.GetComponent<NeuralNetwork>().VFight;

        Vector3 destination_position = new Vector3(
            boids_destination.position.x,
            transform.position.y,
            boids_destination.position.y
        );

        CalculateVelocity(Vdes, Vcen, Vred, Vmat, VFight);

        boids_limit_velocity.LimitVelocity();

        Vector3 target_position = new Vector3(
            transform.position.x + velocity.x,
            transform.position.y,
            transform.position.z + velocity.y
        );
        var targetRotation = Quaternion.LookRotation(target_position - transform.position);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            5.0f * Time.deltaTime
        );

        transform.position += new Vector3(velocity.x, 0.0f, velocity.y);

        corresponding_terrain = AddBoids.GetClosestCurrentTerrain(transform.position);
        transform.position = new Vector3(
            transform.position.x,
            corresponding_terrain.SampleHeight(transform.position) + 3.0f,
            transform.position.z
        );
    }
}
