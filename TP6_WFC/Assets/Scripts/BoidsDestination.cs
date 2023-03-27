using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsDestination : MonoBehaviour
{
    public Camera cam;
    public Vector2 position = new Vector2(0.0f, 0.0f);

    private BoidType boid_type;

    private void Start()
    {
        boid_type = gameObject.GetComponent<BoidsController>().boid_type;
    }

    public Vector2 Destination()
    {
        if (boid_type == BoidType.Cone)
        {
            position = AddBoids.cone_destination;
        }
        else if (boid_type == BoidType.Cube)
        {
            position = AddBoids.cube_destination;
        }
        return (position - new Vector2(transform.position.x, transform.position.z)) / 50;
    }
}
