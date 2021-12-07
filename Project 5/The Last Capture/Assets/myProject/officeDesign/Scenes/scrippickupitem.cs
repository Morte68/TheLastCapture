using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrippickupitem : MonoBehaviour
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
