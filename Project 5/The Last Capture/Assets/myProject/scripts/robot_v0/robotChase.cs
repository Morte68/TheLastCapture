using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotChase : AStateBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform playerPosition;
    [SerializeField] float maxTime;
    float timer;
    float rayDistance = 50.0f;

    public void ResetTimer()
    {
        timer = maxTime;
    }




    public override bool InitializeState()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        return navMeshAgent != null;
    }

    public override void OnStateStart()
    {
        ResetTimer();
    }

    public override void OnStateUpdate()
    {
        Vector3 origion = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            ResetTimer();
        }

        timer -= Time.deltaTime;

        navMeshAgent.destination = playerPosition.position;
    }

    public override void OnStateEnd()
    {
    }

    public override int StateTransitionCondition()
    {
        if (timer <= 0)
        {
            return (int)ERobotState.Patrol;
        }

        return (int)ERobotState.Invalid;
    }
}
