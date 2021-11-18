using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotChase : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform playerPosition;
    [SerializeField] float maxTime;
    float timer;
    float rayDistance = 50.0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        ResetTimer();
    }

    void Update()
    {
        Vector3 origion = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            navMeshAgent.destination = playerPosition.position;
            ResetTimer();
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                navMeshAgent.destination = playerPosition.position;
            }
        }

    }
    public bool chaseStop()
    {
        return timer <= 0;
    }

    public void ResetTimer()
    {
        timer = maxTime;
    }
}
