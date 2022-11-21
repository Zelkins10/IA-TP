using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsLimitVelocity : MonoBehaviour
{
    public GameObject this_boid;
    public int vlim = 10;

    public void LimitVelocity()
    {
        BoidsController boid_controller = this_boid.GetComponent<BoidsController>();
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
