using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsDestination : MonoBehaviour
{
    public Camera cam;
    public Vector2 position = new Vector2(0.0f, 0.0f);

    public Vector2 Destination()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                position = new Vector2(hit.point.x, hit.point.z);
            }
        }
        if (position != new Vector2(0.0f, 0.0f))
        {
            return (position - new Vector2(transform.position.x, transform.position.z)) / 50;
        }
        else
        {
            // TODO : Different destination depending on boid type.
            return -new Vector2(transform.position.x, transform.position.z) / 50;
        }
    }
}
