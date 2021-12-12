using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this file to declare all your states for a given enumeration or statemachine

public enum ERobotState
{
    Invalid = -1,
    Idle = 0,
    Chase = 1,
    Patrol = 2,
    goToChangePoint = 3,
    goToShootPoint = 4,
    afterShoot = 5,
    prepareProtect = 6,
    protect = 7,
}

