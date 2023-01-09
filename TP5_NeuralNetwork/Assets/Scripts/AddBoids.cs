using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static BoidType;

public class AddBoids : MonoBehaviour
{
    public Camera cam;
    public GameObject cone;
    public GameObject cube;
    public int number_of_boids = 100;
    public float vlim = 0.1f;
    public int distance_min = 5;
    public float time_to_start = 5.0f;
    public float game_of_life_time_rate = 3.0f;

    private Terrain terrain;

    // Is static is a good way to do that ?
    public static List<List<GameObject>> lists_of_boids = new List<List<GameObject>>();
    public static List<GameObject> list_of_cubes = new List<GameObject>();
    public static List<GameObject> list_of_cones = new List<GameObject>();
    public static Dictionary<List<GameObject>, List<GameObject>> best_corresponding_boids =
        new Dictionary<List<GameObject>, List<GameObject>>();

    void Start()
    {
        terrain = Terrain.activeTerrain;
        create_boids(number_of_boids);
        add_component_in_boids(list_of_cubes);
        add_component_in_boids(list_of_cones);
        // Keep care about order of adding lists in the main list : need to be the same order than order declaration in the enum.
        lists_of_boids.Add(list_of_cubes);
        lists_of_boids.Add(list_of_cones);
        GameOfLife game_of_life = gameObject.AddComponent<GameOfLife>();
        game_of_life.number_of_boids = number_of_boids;
        game_of_life.time_to_start = time_to_start;
        game_of_life.game_of_life_time_rate = game_of_life_time_rate;
    }

    void create_boids(int nb)
    {
        for (int i = 0; i < nb; i++)
        {
            // Instantiate() needs real coordinates in world space
            Vector2 position = new Vector2(
                Random.Range(-1.5f * terrain.terrainData.size.x, 1.5f * terrain.terrainData.size.x),
                Random.Range(-1.5f * terrain.terrainData.size.z, 1.5f * terrain.terrainData.size.z)
            );

            // Check the terrain where the boid will be created on.
            Terrain corresponding_terrain = GetClosestCurrentTerrain(
                new Vector3(position.x, 0.0f, position.y)
            );

            GameObject character_prefab;
            BoidType boid_type;
            List<GameObject> target_list;

            if (Random.value < 0.5f)
            {
                character_prefab = cone;
                target_list = list_of_cones;
                boid_type = BoidType.Cone;
            }
            else
            {
                character_prefab = cube;
                target_list = list_of_cubes;
                boid_type = BoidType.Cube;
            }

            GameObject new_character = Instantiate(
                character_prefab,
                new Vector3(
                    position.x,
                    corresponding_terrain.SampleHeight(new Vector3(position.x, 0.0f, position.y))
                        + 3.0f,
                    position.y
                ),
                Quaternion.identity
            );
            new_character.name = character_prefab.name + " " + i.ToString();
            BoidsController controller = new_character.AddComponent<BoidsController>();
            controller.boid_type = boid_type;
            target_list.Add(new_character);
        }
    }

    public void add_component_in_boids(List<GameObject> boids)
    {
        foreach (GameObject boid in boids)
        {
            AlgoGen algogen = boid.AddComponent<AlgoGen>();

            BoidsDestination destination = boid.AddComponent<BoidsDestination>();
            destination.cam = cam;

            BoidsCenterOfMass center_of_mass = boid.AddComponent<BoidsCenterOfMass>();
            center_of_mass.distance_max = terrain.terrainData.size.x;

            BoidsReduceDistance reduce_distance = boid.AddComponent<BoidsReduceDistance>();
            reduce_distance.distance_min = distance_min;

            BoidsMatchVelocity match_velocity = boid.AddComponent<BoidsMatchVelocity>();
            center_of_mass.distance_max = terrain.terrainData.size.x;

            BoidsLimitVelocity limit_velocity = boid.AddComponent<BoidsLimitVelocity>();
            limit_velocity.vlim = vlim;
        }
    }

    public static Terrain GetClosestCurrentTerrain(Vector3 playerPos)
    {
        //Get all terrain
        Terrain[] terrains = Terrain.activeTerrains;

        //Make sure that terrains length is ok
        if (terrains.Length == 0)
            return null;

        //If just one, return that one terrain
        if (terrains.Length == 1)
            return terrains[0];

        //Get the closest one to the player
        Vector3 terrainPos = terrains[0].GetPosition();
        terrainPos = new Vector3(
            terrainPos.x + terrains[0].terrainData.size.x / 2.0f,
            0.0f,
            terrainPos.z + terrains[0].terrainData.size.z / 2.0f
        );
        float lowDist = Vector3.Distance(playerPos, terrainPos);
        var terrainIndex = 0;

        for (int i = 1; i < terrains.Length; i++)
        {
            terrainPos = terrains[i].GetPosition();
            terrainPos = new Vector3(
                terrainPos.x + terrains[i].terrainData.size.x / 2.0f,
                0.0f,
                terrainPos.z + terrains[i].terrainData.size.z / 2.0f
            );

            //Find the distance and check if it is lower than the last one then store it
            var dist = Vector3.Distance(playerPos, terrainPos);
            if (dist < lowDist)
            {
                lowDist = dist;
                terrainIndex = i;
            }
        }
        return terrains[terrainIndex];
    }
}
