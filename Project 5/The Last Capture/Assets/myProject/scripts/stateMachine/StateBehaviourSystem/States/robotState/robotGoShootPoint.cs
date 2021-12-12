using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotGoShootPoint : AStateBehaviour
{
    GameObject robot;
    [SerializeField] Transform robotShootPoint;
    [SerializeField] float speed_goDoor = 8f;
    [SerializeField] float time_waitForShoot = 10f;
    [SerializeField] float speed_turn = 0.1f;
    bool IEnumerator_hasLaunched = false;
    bool isStopping = false;


    public override bool InitializeState()
    {
        robot = GameObject.FindWithTag("Robot");
        return robot;
    }

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
        robot.GetComponent<NavMeshAgent>().destination = robotShootPoint.position;
        robot.GetComponent<NavMeshAgent>().speed = speed_goDoor;
        robot.GetComponent<NavMeshAgent>().angularSpeed = 360f;
        //if(robot.transform.hasChanged == false)
        //{

        //    robot.transform.hasChanged = true;
        //}
        //if (Vector3.Distance(robot.transform.position, robotShootPoint.position) <= 2f && isStopping == false)
        //{
        //    isStopping = true;
        //    robot.transform.Rotate(new Vector3(0f, -90f, 0f) * speed_turn * Time.deltaTime);
        //}
    }

    public override int StateTransitionCondition()
    {
        if (Vector3.Distance(robot.transform.position, robotShootPoint.position) <= 2f && IEnumerator_hasLaunched == false)
        {
            IEnumerator_hasLaunched = true;
            robot.transform.Rotate(new Vector3(0f, -90f, 0f) * speed_turn * Time.deltaTime);
            StartCoroutine(Time_waitForShoot());
        }

        return (int)ERobotState.Invalid;
    }

    IEnumerator Time_waitForShoot()
    {
        yield return new WaitForSeconds(time_waitForShoot);
        AssociatedStateMachine.setState((int)ERobotState.afterShoot);
    }
}
