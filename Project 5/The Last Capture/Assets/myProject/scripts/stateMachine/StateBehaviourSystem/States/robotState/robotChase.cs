using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotChase : AStateBehaviour
{
    GameObject player;
    NavMeshAgent navMeshAgent;
    [SerializeField] Animator armMove;
    [SerializeField] Animator headRotate;
    [SerializeField] Renderer color_enemyFace;
    Material colors_enemyFaceMaterial;
    [SerializeField] float maxTime;
    float timer;
    [SerializeField] float rayDistance = 50.0f;
    [SerializeField] float speed_chase = 4f;

    public void ResetTimer()
    {
        timer = maxTime;
    }

    public override bool InitializeState()
    {
        colors_enemyFaceMaterial = color_enemyFace.sharedMaterial;

        player = GameObject.FindWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        return navMeshAgent != null;
    }

    public override void OnStateStart()
    {
        ResetTimer();
        armMove.enabled = true;
        headRotate.enabled = true;

        colors_enemyFaceMaterial.EnableKeyword("_EMISSION");
    }

    public override void OnStateUpdate()
    {
        navMeshAgent.speed = speed_chase;

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

        if(navMeshAgent.enabled == true) navMeshAgent.destination = player.transform.position;
    }

    public override void OnStateEnd()
    {
        colors_enemyFaceMaterial.DisableKeyword("_EMISSION");
        armMove.enabled = false;
        headRotate.enabled = false;
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
