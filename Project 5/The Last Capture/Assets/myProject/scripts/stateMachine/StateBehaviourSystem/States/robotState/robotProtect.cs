using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotProtect : AStateBehaviour
{
    [SerializeField] GameObject navMeshObstacle;
    NavMeshAgent agent;
    [SerializeField] Transform protectPoint = null;
    [SerializeField] Animator robotShield;
    bool isOpenedShield = false;

    [SerializeField] Renderer color_friendFace;
    Material colors_friendFaceMaterial;

    [SerializeField] GameObject deathField;

    [SerializeField] GameObject music_robotProtect;


    public override bool InitializeState()
    {
        colors_friendFaceMaterial = color_friendFace.sharedMaterial;

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
        if(Vector3.Distance(transform.position, protectPoint.position) <= agent.stoppingDistance && isOpenedShield == false)
        {
            colors_friendFaceMaterial.EnableKeyword("_EMISSION");

            robotShield.enabled = true;
            isOpenedShield = true;
            deathField.SetActive(true);
            music_robotProtect.SetActive(true);
        }
    }

    public override int StateTransitionCondition()
    {
        return (int)ERobotState.Invalid;
    }
}