using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsCenterOfMass : MonoBehaviour
{
    public List<GameObject> list_of_boids;
    public GameObject this_boid;

    private Vector2 Vcen = new Vector2(0.0f, 0.0f);

    public Vector2 CenterOfMass()
    {
        foreach (GameObject boid in list_of_boids)
        {
            if (boid != this_boid)
            {
                Vcen += new Vector2(boid.transform.position.x, boid.transform.position.z);
            }
        }
        Vcen /= list_of_boids.Count-1;
        return (Vcen - new Vector2(this_boid.transform.position.x, this_boid.transform.position.z))/1000;
    }
}
