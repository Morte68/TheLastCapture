using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotNavMesh : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    Transform playerPosition;
    // [SerializeField]
    // private Transform trigger_robotMove;

        [SerializeField]
    float maxTime;

    float timer;

    float rayDistance = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // if(playerPosition.position = trigger_robotMove.position)
        // {
        //     navMeshAgent.destination = playerPosition.position;
        // }


        Vector3 origion = transform.position;
        Vector3 direction = transform.forward;
        
        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            navMeshAgent.destination = playerPosition.position;
            ResetTimer();
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer > 0)
            {
                navMeshAgent.destination = playerPosition.position;
            }
        }

    }
    public bool ShouldStopChasing()
    {
        return timer <= 0;
    }

    public void ResetTimer()
    {
        timer = maxTime;
    }
}
