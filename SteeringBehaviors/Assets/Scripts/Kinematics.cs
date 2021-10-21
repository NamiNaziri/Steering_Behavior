using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct KinematicProperties
{
    public Vector3 position;
    public float orientation;

    public Vector3 velocity;
    public float rotation;
}


public class Kinematics : MonoBehaviour
{
    [SerializeField]private BaseSteeringBehavior[] steeringBehaviors;

    public KinematicProperties properties;

    [SerializeField]private bool automaticSteeringGathering = false;

    // Start is called before the first frame update
    public void Start()
    {
        properties.position = transform.position;

        if (automaticSteeringGathering)
        {
            steeringBehaviors = GetComponents<BaseSteeringBehavior>();
        }
    }

    // Update is called once per frame
    void Update()
    {


        properties.position = transform.position;

        for (int i = 0; i < steeringBehaviors.Length; i++)
        {
            if (steeringBehaviors[i] == null || !steeringBehaviors[i].isActiveAndEnabled)
                continue;

            transform.position += properties.velocity * Time.deltaTime;
            

            if (steeringBehaviors[i].ignoreRotation)
            {
                if (properties.velocity.sqrMagnitude > 0)
                    transform.forward = properties.velocity;
            }
            else
            {
                properties.orientation += properties.rotation * Time.deltaTime;
                if (properties.orientation < 0)
                    properties.orientation += 360;
                if (properties.orientation > 360)
                    properties.orientation -= 360;

                transform.forward = new Vector3(Mathf.Sin(properties.orientation * Mathf.Deg2Rad)
                    , 0, Mathf.Cos(properties.orientation * Mathf.Deg2Rad));
            }

            SteeringOutput output = steeringBehaviors[i].GetSteering();

            properties.velocity += output.linear * Time.deltaTime;
            properties.rotation += output.angular * Time.deltaTime;

            properties.position = transform.position;
            
            
            //Return the object to the middle of the screen if it gets too far!
            /*if (transform.position.magnitude > 40)
            {
                transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                transform.Rotate(Vector3.up, Random.Range(0.0f, 360.0f));

                velocity = Vector3.zero;
                rotation = 0;
            }*/
        }
    }
}