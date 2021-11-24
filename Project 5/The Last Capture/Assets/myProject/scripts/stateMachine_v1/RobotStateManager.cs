using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateManager : MonoBehaviour
{
    RobotBaseState currentState;
    public RobotPatrolState patrolState = new RobotPatrolState();
    public RobotChaseState chaseState = new RobotChaseState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = patrolState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(RobotBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
