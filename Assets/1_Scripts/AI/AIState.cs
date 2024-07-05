using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    protected AIController controller;

    public AIState(AIController contr)
    {
        controller = contr;    
    }

    public abstract void OnStateEnter();

    public abstract void OnStateRun();

    public abstract void OnStateExit();

}

