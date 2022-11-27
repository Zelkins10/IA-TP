using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsReduceDistance : MonoBehaviour
{
    public List<GameObject> list_of_boids;
    public GameObject this_boid;
    public int distance_min = 5;

    public Vector2 ReduceDistance()
    {
        Vector2 Vred = new Vector2(0.0f, 0.0f);
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != this_boid)
            {
                if (Vector3.Distance(boid.transform.position, this_boid.transform.position) < distance_min)
                {
                    Vred -= new Vector2(
                        boid.transform.position.x - this_boid.transform.position.x,
                        boid.transform.position.z - this_boid.transform.position.z
                    );
                }
            }
        }
        return Vred;
    }
}
