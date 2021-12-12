using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotGoChangePoint : AStateBehaviour
{
    GameObject robot;
    [SerializeField] Transform robotChangePoint;
    [SerializeField] float speed_return = 8f;
    [SerializeField] float time_waitForChange = 10f;
    bool hasLaunchedIENumerator = false;


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
        robot.GetComponent<NavMeshAgent>().destination = robotChangePoint.position;
        robot.GetComponent<NavMeshAgent>().speed = speed_return;
        robot.GetComponent<NavMeshAgent>().angularSpeed = 360f;
    }

    public override int StateTransitionCondition()
    {
        if (Vector3.Distance(robot.transform.position, robotChangePoint.position) <= 2f && hasLaunchedIENumerator == false)
        {
            hasLaunchedIENumerator = true;
            StartCoroutine(WaitForFixTime());
        }

        return (int)ERobotState.Invalid;
    }

    IEnumerator WaitForFixTime ()
    {
        yield return new WaitForSeconds(time_waitForChange);
        AssociatedStateMachine.setState((int)ERobotState.goToShootPoint);
        //hasLaunchedIENumerator = false;
    }
}
