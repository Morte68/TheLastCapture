using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotPatrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] patrolPoints;
    int patrolIndex = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        patrol();
        if(Vector3.Distance(transform.position, patrolPoints[patrolIndex].position) < 0.5f)
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
        if(patrolIndex >= patrolPoints.Length)
        {
            patrolIndex = 0;
        }
    }

}
