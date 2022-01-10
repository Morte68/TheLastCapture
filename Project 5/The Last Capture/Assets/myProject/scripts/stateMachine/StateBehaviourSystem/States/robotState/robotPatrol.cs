using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotPatrol : AStateBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] Animator armMove;
    [SerializeField] float rayDistance = 50.0f;
    int patrolIndex = 0;
    [SerializeField] float speed_patrol = 2f;

    void patrol()
    {
        if(navMeshAgent.enabled == true) navMeshAgent.destination = patrolPoints[patrolIndex].position;
    }

    void patrolLoop()
    {
        patrolIndex++;
        if(patrolIndex >= patrolPoints.Length)
        {
            patrolIndex = 0;
        }
    }

    public override bool InitializeState()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        return navMeshAgent != null;
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
        navMeshAgent.speed = speed_patrol;
        patrol();
        if (Vector3.Distance(transform.position, patrolPoints[patrolIndex].position) < 2f)
        {
            patrolLoop();
        }
    }

    public override void OnStateEnd()
    {
    }

    public override int StateTransitionCondition()
    {
        if (PlayerDetected())
        {
            return (int)ERobotState.Chase;
        }

        return (int)ERobotState.Invalid;
    }

    private bool PlayerDetected()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
        Ray ray = new Ray(origin, direction);
        RaycastHit raycastHit;
        return Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player");
    }
}
