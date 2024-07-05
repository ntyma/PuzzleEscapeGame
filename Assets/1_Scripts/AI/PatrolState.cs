using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolState : AIState
{
    private int waypointIndex;

    public PatrolState(AIController contr) : base(contr)
    {
    }

    public override void OnStateEnter()
    {
        //agent.SetDestination(Vector3.right * 10);
        Debug.Log("patrol enter");
        controller.GetAgent().SetDestination(controller.GetPath()[waypointIndex].position);
    }

    public override void OnStateExit()
    {
        Debug.Log("patrol exut");
    }

    public override void OnStateRun()
    {
        if (controller.GetAgent().remainingDistance <= controller.GetAgent().stoppingDistance)
        {
            waypointIndex++;
            if (waypointIndex >= controller.GetPath().Length)
            {
                waypointIndex = 0;
            }
            controller.GetAgent().SetDestination(controller.GetPath()[waypointIndex].position);

        }

        //Debug.Log("patrol running");
    }
}
