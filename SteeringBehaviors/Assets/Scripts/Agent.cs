using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : BaseSteeringBehavior
{

    private BaseSteeringBehavior CurrentAgentBehavoir;
    [SerializeField]private pursue pursueBehavior;
    [SerializeField] private Arrive arriveBehavior;


    private bool flipFlop = true;
    // Start is called before the first frame update
    public override void Start()  
    {
        CurrentAgentBehavoir = pursueBehavior;
        
    }

    public override SteeringOutput GetSteering()
    {
        return CurrentAgentBehavoir.GetSteering();
    }
    // Update is called once per frame
    public override void Update()
    {
        
        if (flipFlop && CurrentAgentBehavoir.IsReached())
        {
            flipFlop = false;
            CurrentAgentBehavoir = arriveBehavior;
        }
        else if ( !CurrentAgentBehavoir.IsReached())
        {
            CurrentAgentBehavoir = pursueBehavior;
            flipFlop = true;
        }
    }
}
