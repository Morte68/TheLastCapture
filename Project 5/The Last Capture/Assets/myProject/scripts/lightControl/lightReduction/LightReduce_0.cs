using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReduce_0 : MonoBehaviour
{
    //[SerializeField] Light doorLight;
    //[SerializeField] float intensity_doorLight = 2f;
    [SerializeField] Renderer[] rend;
    [SerializeField] Material unlit;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //doorLight.intensity = intensity_doorLight;
            for(int i = 0; i < rend.Length; i++)
            {
                rend[i].sharedMaterial = unlit;
            }
        }
    }
}
