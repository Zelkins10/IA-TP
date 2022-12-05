using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsSeparation : MonoBehaviour
{
    public float desiredSeparation = 3.0f;
    public List<GameObject> others_boids;

    public Vector2 Separation()
    {
        foreach (GameObject other in others_boids)
        {
            if (other != null)
            {
                float distance = (transform.position - other.transform.position).magnitude;

                if ((distance > 0) && (distance < desiredSeparation))
                {
                    return new Vector2(0, 0);
                }
            }
        }
        return new Vector2(0, 0);
    }
}
