using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

using static BoidType;

public class AddBoids : MonoBehaviour
{
    public Camera cam;
    public GameObject cone;
    public GameObject cube;
    public float vlim = 0.1f;
    public int distance_min = 5;
    public float time_to_start = 5.0f;
    public float game_of_life_time_rate = 3.0f;
    public List<GameObject> list_of_cubes = new List<GameObject>();
    public List<GameObject> list_of_cones = new List<GameObject>();

    private Terrain terrain;

    // Is static is a good way to do that ?
    static public int number_of_boids = 100;
    public static List<List<GameObject>> lists_of_boids = new List<List<GameObject>>();
    public static Dictionary<List<GameObject>, List<GameObject>> best_corresponding_boids =
        new Dictionary<List<GameObject>, List<GameObject>>(); // TODO : Rename this.

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
            WFC wfc = GameObject.Find("WFC").GetComponent<WFC>();
            Vector2 position = new Vector2(
                Random.Range(-62.5F * (wfc.size_x - 1), 62.5F * (wfc.size_x - 1)),
                Random.Range(-62.5F * (wfc.size_z - 1), 62.5F * (wfc.size_z - 1))
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

            UnityEngine.AI.NavMeshHit hit;
            if (
                UnityEngine.AI.NavMesh.SamplePosition(
                    new Vector3(position.x, 0.0f, position.y),
                    out hit,
                    100.0f,
                    UnityEngine.AI.NavMesh.AllAreas
                )
            )
            {
                GameObject new_character = Instantiate(
                    character_prefab,
                    hit.position,
                    Quaternion.identity
                );
                new_character.name = character_prefab.name + " " + i.ToString();
                BoidsController controller = new_character.AddComponent<BoidsController>();
                controller.boid_type = boid_type;
                target_list.Add(new_character);
            }
        }
    }

    public void add_component_in_boids(List<GameObject> boids)
    {
        foreach (GameObject boid in boids)
        {
            AlgoGen algogen = boid.AddComponent<AlgoGen>();

            NeuralNetwork neural_network = boid.AddComponent<NeuralNetwork>();

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

            boid.AddComponent<UnityEngine.AI.NavMeshAgent>();
        }
    }
}
