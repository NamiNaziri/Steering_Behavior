using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : BaseSteeringBehavior
{
    public float maxAcceleration = 2.5f;

    public override SteeringOutput GetSteering()
    {
        SteeringOutput steering;
        steering.linear = Vector3.zero;
        steering.angular = 0;

        steering.linear = maxAcceleration * character.transform.forward;
        

        return steering;
    }
}
