using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotIdle : AStateBehaviour
{
    public override bool InitializeState()
    {
        return true;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
    }

    public override int StateTransitionCondition()
    {
        return (int)ERobotState.Invalid;
    }
}
