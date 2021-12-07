using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforceFollowParent : MonoBehaviour
{
    public Transform transformToFollow = null;
    void Update()
    {
        if(transformToFollow)
        {
            transform.position = transformToFollow.position;
        }
    }
}
