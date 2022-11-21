using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsDestination : MonoBehaviour
{
    public Camera cam;
    public GameObject this_boid;
    private Vector2 position = new Vector2(0.0f, 0.0f);

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
        return (
                position
                - new Vector2(this_boid.transform.position.x, this_boid.transform.position.z)
            ) / 1000;
    }
}
