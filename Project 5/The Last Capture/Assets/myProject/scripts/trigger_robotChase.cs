using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_robotChase : MonoBehaviour
{
    public GameObject robot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            robot.GetComponent<StateMachine>().setState((int)ERobotState.Chase);
            gameObject.SetActive(false);
        }
    }
}
