using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursue : SeekAndFlee
{
    //public Kinematics pursueTarget;
    public float maxPrediction = 3f;
    
   

    public override SteeringOutput GetSteering()
    {
        if (target)
        {

            float prediction = 0;

            Vector3 direction = effectiveTarget.position - character.transform.position;
            float distance = direction.magnitude;
            float speed = characterKinematics.velocity.magnitude;

            if (speed < distance / maxPrediction)
            {
                prediction = maxPrediction;
            }
            else
            {
                prediction = distance / speed;
            }

            if ((character.transform.position - effectiveTarget.position).sqrMagnitude <
                (maxReachDistance * maxReachDistance))
            {
                isReached = true;
                print("Reached the target");
            }
            else
            {
                isReached = false;
            }

            base.effectiveTarget.position = base.target.transform.position;
            base.effectiveTarget.position += effectiveTarget.velocity * prediction;
            
            


            Debug.DrawLine(character.transform.position, base.effectiveTarget.position,Color.red);
            Debug.DrawLine(character.transform.position, base.target.transform.position, Color.green);

        }

        return base.GetSteering();
    }

    
}
