using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoids : MonoBehaviour
{
    public Camera cam;
    public GameObject child_object;
    public List<GameObject> children;
    public int number_of_boids = 100;
    public float vlim = 0.1f;
    public int distance_min = 5;
    public float acceptance_radius = 50.0f;
    public Terrain terrain;

    void Start()
    {
        for (int i = 0; i < number_of_boids; i++)
        {
            Vector2Int positionXY = new Vector2Int(Random.Range(0, terrain.terrainData.heightmapResolution), Random.Range(0, terrain.terrainData.heightmapResolution));
            Vector2 positionFloat = new Vector2((float)positionXY.x/terrain.terrainData.heightmapResolution*1000.0f-500.0f, (float)positionXY.y/terrain.terrainData.heightmapResolution*1000.0f-500.0f);
            GameObject new_character = Instantiate(
                child_object,
                new Vector3(positionFloat.x, terrain.terrainData.GetHeight(positionXY.x, positionXY.y)+0.5f, positionFloat.y),
                Quaternion.identity
            );
            new_character.name = i.ToString();
            children.Add(new_character);
        }
        foreach (GameObject child in children)
        {
            BoidsController controller = child.AddComponent<BoidsController>();
            controller.list_of_boids = children;
            controller.acceptance_radius = acceptance_radius;
            controller.terrain = terrain;

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
