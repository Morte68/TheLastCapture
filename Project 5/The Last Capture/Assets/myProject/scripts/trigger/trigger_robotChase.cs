using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_robotChase : MonoBehaviour
{
    GameObject robot;

    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            robot.GetComponent<StateMachine>().setState((int)ERobotState.Chase);
            Destroy(gameObject);
        }
    }
}
