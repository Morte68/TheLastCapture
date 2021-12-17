using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotPrepareProtect : AStateBehaviour
{
    [SerializeField] GameObject fire_end;
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
        if(fire_end.activeInHierarchy == true)
        {
            return (int)ERobotState.protect;
        }
        return (int)ERobotState.Invalid;
    }
}
