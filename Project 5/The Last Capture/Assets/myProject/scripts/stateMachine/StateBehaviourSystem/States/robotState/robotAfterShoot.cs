//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class robotAfterShoot : AStateBehaviour
//{
//    GameObject robot;
//    [SerializeField] Transform afterShootPoint;
//    [SerializeField] float speed_afterShoot = 4f;


//    public override bool InitializeState()
//    {
//        robot = GameObject.FindWithTag("Robot");
//        return robot;
//    }

//    public override void OnStateEnd()
//    {
//    }

//    public override void OnStateStart()
//    {
//    }

//    public override void OnStateUpdate()
//    {
//        robot.GetComponent<NavMeshAgent>().destination = afterShootPoint.position;
//        robot.GetComponent<NavMeshAgent>().speed = speed_afterShoot;
//        robot.GetComponent<NavMeshAgent>().angularSpeed = 360f;
//    }

//    public override int StateTransitionCondition()
//    {
      
//    }
//}
