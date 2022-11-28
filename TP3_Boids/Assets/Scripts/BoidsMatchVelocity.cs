using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsMatchVelocity : MonoBehaviour
{
    public List<GameObject> list_of_boids;
    public GameObject this_boid;
    public float distance_max = 100.0f;

    public Vector2 MatchVelocity()
    {
        Vector2 Vmat = new Vector2(0.0f, 0.0f);
        int count = 0;
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != this_boid)
            {
                if (Vector3.Distance(boid.transform.position, this_boid.transform.position) < distance_max)
                {
                    BoidsController boid_controller = boid.GetComponent<BoidsController>();
                    Vmat += boid_controller.velocity;
                }
            }
        }
        if(count > 0)
        {
            Vmat /= count;
            BoidsController this_boid_controller = this_boid.GetComponent<BoidsController>();
            return (Vmat - this_boid_controller.velocity)/20;
        }
        else
        {
            return new Vector2(0.0f, 0.0f);
        }
    }
}
