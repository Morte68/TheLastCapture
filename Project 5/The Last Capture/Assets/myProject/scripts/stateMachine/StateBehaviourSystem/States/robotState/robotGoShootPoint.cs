using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotGoShootPoint : AStateBehaviour
{
    GameObject robot;
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform playerPosition;

    // degree of rotation each sec
    [SerializeField] float speed = 30f;

    [SerializeField] GameObject[] VFX_shoot;
    [SerializeField] Transform door;
    [SerializeField] Transform robotShootPoint;
    [SerializeField] Animator animator_doorCrush;
    [SerializeField] float speed_goDoor = 8f;
    [SerializeField] float speed_turn = 0.1f;
    [SerializeField] float time_shoot_0 = 1.5f;
    [SerializeField] float time_shoot_1 = 1.5f;
    [SerializeField] float time_shoot_2 = 1.5f;
    [SerializeField] float time_doorCrush = 0.5f;
    [SerializeField] float time_finishing = 1.5f;
    bool IEnumerator_hasLaunched = false;
    bool isFacingDoor = false;

    [SerializeField] GameObject range_move;
    bool isStoppable = true;

    [SerializeField] GameObject sfx_loading;
    [SerializeField] GameObject sfx_firing;

    [Header("Material=========================")]
    [SerializeField] Renderer rend;
    [SerializeField] Material followMe;
    [SerializeField] Material thankU;


    public override bool InitializeState()
    {
        robot = GameObject.FindWithTag("Robot");
        navMeshAgent = GetComponent<NavMeshAgent>();
        return robot;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
        isFacingDoor = false;
        rend.sharedMaterial = followMe;
        navMeshAgent.speed = speed_goDoor;
        navMeshAgent.angularSpeed = 360f;
    }

    public override void OnStateUpdate()
    {
       float distanceToDestinatison = Vector3.Distance(robot.transform.position, robotShootPoint.position);
        var rot = Quaternion.LookRotation(transform.position - playerPosition.position);

        if (distanceToDestinatison <= robot.GetComponent<NavMeshAgent>().stoppingDistance + 1)
        {
            isStoppable = false;
        }
        if(range_move.GetComponent<RobotMove>().isStaying == true)
        {
            navMeshAgent.enabled = true;
            if (distanceToDestinatison >= robot.GetComponent<NavMeshAgent>().stoppingDistance)
            {
                navMeshAgent.destination = robotShootPoint.position;
            }
            else if (isFacingDoor == false)
            {
                isStoppable = false;
                robot.transform.Rotate(new Vector3(0f, -90f, 0f) * speed_turn * Time.deltaTime);

                Vector3 robotPositionXZ = transform.position;
                Vector3 doorPositonXZ = door.position;
                Vector3 forwardXZ = transform.forward;

                robotPositionXZ.y = 0;
                doorPositonXZ.y = 0;
                forwardXZ.y = 0;

                Vector3 direction = (doorPositonXZ - robotPositionXZ).normalized;
                float dotProduct = Vector3.Dot(forwardXZ, direction);
                if (dotProduct >= 0.9f)
                {
                    isFacingDoor = true;
                }
            }
        }
        else
        {
            if (isStoppable == true)
            {
                navMeshAgent.enabled = false;
                //transform.LookAt(playerPosition);
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, speed * Time.deltaTime); //rotate towards over time

            }
        }
    }

    public override int StateTransitionCondition()
    {
        if (isFacingDoor && IEnumerator_hasLaunched == false)
        {
            IEnumerator_hasLaunched = true;
            StartCoroutine(Time_waitForShoot());
        }

        return (int)ERobotState.Invalid;
    }

    // robot shooting sequence
    IEnumerator Time_waitForShoot()
    {
        yield return new WaitForSeconds(time_shoot_0);
        VFX_shoot[0].SetActive(true);
        sfx_loading.SetActive(true);

        yield return new WaitForSeconds(time_shoot_1);
        VFX_shoot[1].SetActive(true);

        yield return new WaitForSeconds(time_shoot_2);
        VFX_shoot[2].SetActive(true);
        
        yield return new WaitForSeconds(time_doorCrush);
        VFX_shoot[3].SetActive(true);
        sfx_firing.SetActive(true);
        animator_doorCrush.enabled = true;
        for(int i = 0; i <= 2; i++)
        {
            VFX_shoot[i].SetActive(false);
        }

        yield return new WaitForSeconds(time_finishing);
        rend.sharedMaterial = thankU;
        AssociatedStateMachine.setState((int)ERobotState.afterShoot);
    }

}
