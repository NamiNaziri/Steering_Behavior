using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    public override SteeringOutput GetSteering()
    {
        SteeringOutput steering;
        steering.linear = Vector3.zero;
        steering.angular = 0;

        Vector3 direction = effectiveTarget.position - characterKinematics.position;
        if (direction.magnitude == 0)
        {
            return steering;
        }

        base.effectiveTarget.orientation = Mathf.Atan2(-direction.x, direction.z) * Mathf.Rad2Deg;
        return base.GetSteering();
    }
}
