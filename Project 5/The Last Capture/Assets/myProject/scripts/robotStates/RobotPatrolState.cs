using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotPatrolState : RobotBaseState
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] patrolPoints;
    int patrolIndex = 0;

    public override void EnterState(RobotStateManager robot)
    {
        Debug.Log("hello I am here");
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void UpdateState(RobotStateManager robot)
    {
        patrol();
        if (Vector3.Distance(transform.position, patrolPoints[patrolIndex].position) < 0.5f)
        {
            patrolLoop();
        }
    }

    void patrol()
    {
        navMeshAgent.destination = patrolPoints[patrolIndex].position;
    }

    void patrolLoop()
    {
        patrolIndex++;
        if (patrolIndex >= patrolPoints.Length)
        {
            patrolIndex = 0;
        }
    }

    public override void OnCollisionEnter(RobotStateManager robot)
    {

    }
}
