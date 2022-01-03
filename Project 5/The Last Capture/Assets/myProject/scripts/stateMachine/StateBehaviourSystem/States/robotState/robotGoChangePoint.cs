using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotGoChangePoint : AStateBehaviour
{
    //GameObject robot;

    [SerializeField] GameObject[] VFX_changes;
    [SerializeField] GameObject[] VFX_electricity;
    [SerializeField] GameObject[] robotFaces;

    [SerializeField] Transform robotChangePoint;
    [SerializeField] Animator protectionGlassOpen;
    [SerializeField] Animator armMove;
    [SerializeField] Animator roboticArm;

    [SerializeField] float speed_return = 8f;
    [SerializeField] float time_waitForChange = 3f;
    [SerializeField] float time_VFX_0 = 1f;
    [SerializeField] float time_VFX_1 = 1f;
    [SerializeField] float time_overwriteDoorOpen = 1f;
    //[SerializeField] float time_roboticArmStart = 4f;

    bool hasLaunchedIENumerator = false;

    Health playerHealth;

    NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] changePoints;
    int changePointIndex = 0;
    bool isChangePointDone = false;

    [SerializeField] GameObject smokeFire;
    [SerializeField] GameObject sfx_mechanicalArm;



public override bool InitializeState()
    {
        playerHealth = FindObjectOfType<Health>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        return navMeshAgent != null;
        //robot = GameObject.FindWithTag("Robot");
        //return robot;
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

        playerHealth.isDamageable_robot = false;
    }

    public override void OnStateUpdate()
    {
        //navMeshAgent.destination = robotChangePoint.position;
        navMeshAgent.speed = speed_return;
        navMeshAgent.angularSpeed = 360f;

        if(isChangePointDone == false)
        {
            ChangePointGo();
            if (Vector3.Distance(transform.position, changePoints[changePointIndex].position) <= navMeshAgent.stoppingDistance)
            {
                ChangePointSwitch();
            }
        }
    }

    public override int StateTransitionCondition()
    {
        if (Vector3.Distance(transform.position, robotChangePoint.position) <= navMeshAgent.stoppingDistance && hasLaunchedIENumerator == false)
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
        roboticArm.enabled = true;
        sfx_mechanicalArm.SetActive(true);
        yield return new WaitForSeconds(time_VFX_0);
        VFX_changes[1].SetActive(true);
        robotFaces[0].SetActive(false);
        robotFaces[1].SetActive(true);
        yield return new WaitForSeconds(time_VFX_1);
        protectionGlassOpen.SetBool("isOpen", true);
        yield return new WaitForSeconds(time_overwriteDoorOpen);
        smokeFire.SetActive(true);
        AssociatedStateMachine.setState((int)ERobotState.goToShootPoint);
        //hasLaunchedIENumerator = false;
    }

    void ChangePointGo()
    {
        if (navMeshAgent.enabled == true) navMeshAgent.destination = changePoints[changePointIndex].position;
    }

    void ChangePointSwitch()
    {
        changePointIndex++;
        if (changePointIndex >= changePoints.Length)
        {
            isChangePointDone = true;
        }
    }
}
