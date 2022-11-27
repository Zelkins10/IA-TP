using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsMatchVelocity : MonoBehaviour
{
    public List<GameObject> list_of_boids;
    public GameObject this_boid;

    public Vector2 MatchVelocity()
    {
        Vector2 Vmat = new Vector2(0.0f, 0.0f);
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != this_boid)
            {
                BoidsController boid_controller = boid.GetComponent<BoidsController>();
                Vmat += boid_controller.velocity;
            }
        }
        Vmat /= list_of_boids.Count - 1;
        BoidsController this_boid_controller = this_boid.GetComponent<BoidsController>();
        return (Vmat - this_boid_controller.velocity)/20;
    }
}
