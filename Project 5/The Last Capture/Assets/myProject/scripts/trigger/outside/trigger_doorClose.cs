using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_doorClose : MonoBehaviour
{
    [SerializeField] Animator doorClose;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            doorClose.SetBool("isClose", true);
        }
    }
}
