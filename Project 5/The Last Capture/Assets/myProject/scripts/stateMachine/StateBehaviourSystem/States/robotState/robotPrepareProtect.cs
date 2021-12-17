using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotPrepareProtect : AStateBehaviour
{
    [SerializeField] Transform teleportTarget = null;
    public override bool InitializeState()
    {
        return true;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
        transform.position = teleportTarget.position;
        transform.rotation = teleportTarget.rotation;
    }

    public override void OnStateUpdate()
    {
    }

    public override int StateTransitionCondition()
    {
        return (int)ERobotState.Invalid;
    }
}
