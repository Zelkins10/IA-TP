using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsCenterOfMass : MonoBehaviour
{
    private Vector2 Vcen = new Vector2(0.0f, 0.0f);
    public float distance_max = 100.0f;

    public Vector2 CenterOfMass()
    {
        int count = 0;
        foreach (
            GameObject boid in AddBoids.lists_of_boids[
                (int)gameObject.GetComponent<BoidsController>().boid_type
            ]
        )
        {
            if (boid != gameObject)
            {
                if (Vector3.Distance(boid.transform.position, transform.position) < distance_max)
                {
                    Vcen += new Vector2(boid.transform.position.x, boid.transform.position.z);
                    ++count;
                }
            }
        }
        if (count > 0)
        {
            Vcen /= count;
            return (Vcen - new Vector2(transform.position.x, transform.position.z)) / 100;
        }
        else
        {
            return new Vector2(0.0f, 0.0f);
        }
    }
}
