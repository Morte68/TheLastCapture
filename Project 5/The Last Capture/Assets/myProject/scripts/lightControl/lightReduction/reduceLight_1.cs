using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reduceLight_1 : MonoBehaviour
{
    [SerializeField] Light doorLight;
    [SerializeField] float intensity_doorLight = 2f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorLight.intensity = intensity_doorLight;
        }
    }
}
