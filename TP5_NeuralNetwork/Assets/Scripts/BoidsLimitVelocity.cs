using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsLimitVelocity : MonoBehaviour
{
    public float vlim;

    public void LimitVelocity()
    {
        BoidsController boid_controller = GetComponent<BoidsController>();
        if (Mathf.Abs(boid_controller.velocity.x) > vlim)
        {
            boid_controller.velocity.x =
                (boid_controller.velocity.x / Mathf.Abs(boid_controller.velocity.x)) * vlim;
        }
        if (Mathf.Abs(boid_controller.velocity.y) > vlim)
        {
            boid_controller.velocity.y =
                (boid_controller.velocity.y / Mathf.Abs(boid_controller.velocity.y)) * vlim;
        }
    }
}
