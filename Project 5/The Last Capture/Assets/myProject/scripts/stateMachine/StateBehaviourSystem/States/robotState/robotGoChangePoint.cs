using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotGoChangePoint : AStateBehaviour
{
    GameObject robot;
    [SerializeField] GameObject[] VFX_changes;
    [SerializeField] GameObject[] VFX_electricity;
    [SerializeField] GameObject[] robotFaces;
    [SerializeField] Transform robotChangePoint;
    [SerializeField] Animator protectionGlassOpen;
    [SerializeField] float speed_return = 8f;
    [SerializeField] float time_waitForChange = 1f;
    [SerializeField] float time_VFX_0 = 1f;
    [SerializeField] float time_VFX_1 = 1f;
    [SerializeField] float time_overwriteDoorOpen = 1f;
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
        for (int i = 0; i < VFX_electricity.Length; i++)
        {
            VFX_electricity[i].SetActive(false);
        }
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
        VFX_changes[0].SetActive(true);
        yield return new WaitForSeconds(time_VFX_0);
        VFX_changes[1].SetActive(true);
        robotFaces[0].SetActive(false);
        robotFaces[1].SetActive(true);
        yield return new WaitForSeconds(time_VFX_1);
        protectionGlassOpen.SetBool("isOpen", true);
        yield return new WaitForSeconds(time_overwriteDoorOpen);
        AssociatedStateMachine.setState((int)ERobotState.goToShootPoint);
        //hasLaunchedIENumerator = false;
    }
}
