using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    private Transform targetToChase;
    private float originalSpeed;

    public ChaseState(AIController contr, Transform target) : base(contr)
    {
        targetToChase = target;
    }

    public override void OnStateEnter()
    {
        originalSpeed = controller.GetAgent().speed;
        controller.GetAgent().speed = originalSpeed * 2.5f;
    }

    public override void OnStateExit()
    {
        controller.GetAgent().speed = originalSpeed;
    }

    public override void OnStateRun()
    {
        controller.GetAgent().SetDestination(targetToChase.position);
    }
}
