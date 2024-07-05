using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    private Transform targetToChase;

    public ChaseState(AIController contr, Transform target) : base(contr)
    {
    }

    public override void OnStateEnter()
    {

        Debug.Log("chase enter");
    }

    public override void OnStateExit()
    {
        Debug.Log("chase exit");
    }

    public override void OnStateRun()
    {
        Debug.Log("chase is happening");
        controller.GetAgent().SetDestination(targetToChase.position);
        if (controller.GetAgent().remainingDistance <= controller.GetAgent().stoppingDistance)
        {

        }

    }
}
