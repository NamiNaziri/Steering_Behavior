using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SeekAndFlee : BaseSteeringBehavior
{
    
    public bool flee = false;
    public float maxAcceleration = 2.5f;


    public override SteeringOutput GetSteering()
    {
        SteeringOutput steering;
        steering.linear = Vector3.zero;
        steering.angular = 0;

        if (target)
        {
            


            steering.linear = effectiveTarget.position - character.transform.position;
            if (flee)
                steering.linear *= -1;

            steering.linear.y = 0;
            steering.linear.Normalize();
            steering.linear *= maxAcceleration;
        }

        return steering;
    }

    
}