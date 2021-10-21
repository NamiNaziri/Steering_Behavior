using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : Face
{
    public float wanderOffset = 5f;
    public float wanderRadius = 2.5f;
    //maximum rate at which the wander orientation can change
    public float wanderRate = 2.5f;
    //Current orientation of the wander target
    public float wanderOrientation;

    public float maxAcceleration = 2.5f;

    
    
    public override SteeringOutput GetSteering()
    {
        SteeringOutput steering;
        steering.linear = Vector3.zero;
        steering.angular = 0;


        wanderOrientation += Random.Range(-1, -1) * wanderRate;
        float targetOrientation = wanderOrientation + characterKinematics.orientation;

        Vector3 characterOrientationAsVector = new Vector3(Mathf.Sin(characterKinematics.orientation * Mathf.Deg2Rad)
                                         , 0, Mathf.Cos(characterKinematics.orientation * Mathf.Deg2Rad));
        Vector3 targetCenter = characterKinematics.position + wanderOffset * characterOrientationAsVector;

        DrawCircle(targetCenter, wanderRadius);


        Vector3 TargetOrientationAsVector = new Vector3(Mathf.Sin(targetOrientation * Mathf.Deg2Rad)
            , 0, Mathf.Cos(targetOrientation * Mathf.Deg2Rad));

        effectiveTarget.position = targetCenter + wanderRate * TargetOrientationAsVector;

        steering = base.GetSteering();


        steering.linear = maxAcceleration * characterOrientationAsVector;

        return steering;
    }


    private void DrawCircle(Vector3 center, float radius)
    {
        LineRenderer LineDrawer = GetComponent<LineRenderer>();

        if (!LineDrawer)
        {
            LineDrawer = gameObject.AddComponent<LineRenderer>();
        }

        float Theta = 0f;
        float ThetaScale = 0.01f;
        int Size = (int)((1f / ThetaScale) +1f);
        LineDrawer.positionCount = Size;
        for (int i = 0; i < Size; i++)
        {
            Theta += (float)(2.0 * Mathf.PI* ThetaScale);
            float x = radius * Mathf.Sin(Theta);
            float z = radius * Mathf.Cos(Theta);
            LineDrawer.SetPosition(i, new Vector3(x, 0, z) + center);
        }

}
}
