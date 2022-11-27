using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsCenterOfMass : MonoBehaviour
{
    public List<GameObject> list_of_boids;
    public GameObject this_boid;

    private Vector2 Vcen = new Vector2(0.0f, 0.0f);
    public float distance_max = 100.0f;

    public Vector2 CenterOfMass()
    {
        int count = 0;
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != this_boid)
            {
                if (
                    Mathf.Abs(
                        Vector3.Distance(boid.transform.position, this_boid.transform.position)
                    ) < distance_max
                )
                {
                    Vcen += new Vector2(boid.transform.position.x, boid.transform.position.z);
                    ++count;
                }
            }
        }
        if(count > 0)
        {
            Vcen /= count;
            return (Vcen - new Vector2(this_boid.transform.position.x, this_boid.transform.position.z))/10000;
        }
        else
        {
            return new Vector2(0.0f, 0.0f);
        }
    }
}
