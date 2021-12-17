using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotProtect : AStateBehaviour
{
    [SerializeField] GameObject navMeshObstacle;
    NavMeshAgent agent;
    [SerializeField] Transform protectPoint = null;
    public override bool InitializeState()
    {
        agent = GetComponent<NavMeshAgent>();
        return true;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
        agent.enabled = true;
        navMeshObstacle.SetActive(true);
    }

    public override void OnStateUpdate()
    {
        agent.destination = protectPoint.position;
    }

    public override int StateTransitionCondition()
    {
        return (int)ERobotState.Invalid;
    }
}