using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotAfterShoot : AStateBehaviour
{
    GameObject robot;
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] Transform robotAfterShoot_left;
    [SerializeField] Transform robotAfterShoot_right;
    [SerializeField] float speed_afterShoot = 4f;
    [SerializeField] float speed_turn = 0.1f;
    bool hasSetDestination = false;


    public override bool InitializeState()
    {
        robot = GameObject.FindWithTag("Robot");
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        return robot;
    }

    public override void OnStateEnd()
    {
        agent.enabled = false;
    }

    public override void OnStateStart()
    {
        hasSetDestination = false;
        agent.enabled = true;
    }

    public override void OnStateUpdate()
    {
        if (hasSetDestination)
            return;
        agent.speed = speed_afterShoot;
        agent.angularSpeed = 360f;

        robot.transform.Rotate(new Vector3(0f, -90f, 0f) * speed_turn * Time.deltaTime);

        Vector3 robotPositionXZ = transform.position;
        Vector3 playerPositonXZ = player.transform.position;
        Vector3 rightXZ = transform.right;

        robotPositionXZ.y = 0;
        playerPositonXZ.y = 0;
        rightXZ.y = 0;

        Vector3 direction = (playerPositonXZ - robotPositionXZ).normalized;
        float dotProduct_right = Vector3.Dot(rightXZ, direction);


        if (dotProduct_right > 0f)
        {
            agent.destination = robotAfterShoot_left.position;
            hasSetDestination = true;
        }
        else
        {
            agent.destination = robotAfterShoot_right.position;
            hasSetDestination = true;
        }
    }

    public override int StateTransitionCondition()
    {
        if(Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance)
        {
            return (int)ERobotState.Idle;
        }
        return (int)ERobotState.Invalid;
    }
}
