using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SteeringOutput
{
    public Vector3 linear;
    public float angular;
}

public class BaseSteeringBehavior : MonoBehaviour
{
    protected GameObject character;
    protected KinematicProperties characterKinematics; 
    /**
	 * this is the actual target that being used for calculation
	 * For behavior like seek is the sate as target but for something like pursue could be different. For example deference in location 
	 */
    protected KinematicProperties effectiveTarget;

    public GameObject target;


    public bool ignoreRotation = true;
    public float maxReachDistance = 5f;
    protected bool isReached = false;
    public virtual void Start()
    {
        character = gameObject;
        characterKinematics = character.GetComponent<Kinematics>().properties;
        if (target)
        {
            //target = new GameObject();
            //target.AddComponent<Kinematics>();
            effectiveTarget = target.GetComponent<Kinematics>().properties;
        }
        
    }

    public virtual void Update()
    {
        characterKinematics = character.GetComponent<Kinematics>().properties;
        if (target)
        {
            effectiveTarget = target.GetComponent<Kinematics>().properties;
        }
    }

    public virtual SteeringOutput GetSteering()
    {
        SteeringOutput steering;
        steering.linear = Vector3.zero;
        steering.angular = 0;
        return steering; 
    }

    public virtual bool IsReached()
    {
        return isReached;
    }

    public void UpdateEffectiveTarget(KinematicProperties kp)
    {
        effectiveTarget = kp;
    }

    public void UpdateCharacterKinematics(KinematicProperties ck)
    {
        characterKinematics = ck;
    }
}