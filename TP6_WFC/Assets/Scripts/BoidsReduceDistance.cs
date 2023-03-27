using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsReduceDistance : MonoBehaviour
{
    public int distance_min = 5;

    public Vector2 ReduceDistance()
    {
        Vector2 Vred = new Vector2(0.0f, 0.0f);
        foreach (List<GameObject> list_of_boids in AddBoids.lists_of_boids)
        {
            foreach (GameObject boid in list_of_boids)
            {
                if (boid != gameObject)
                {
                    if (
                        Vector3.Distance(boid.transform.position, transform.position) < distance_min
                    )
                    {
                        Vred -= new Vector2(
                            boid.transform.position.x - transform.position.x,
                            boid.transform.position.z - transform.position.z
                        );
                    }
                }
            }
        }
        return Vred;
    }
}
