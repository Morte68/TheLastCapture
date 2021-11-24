using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 50.0f;
    Color colorChange = Color.red;
    Color colorOrigion = Color.white;
 
    void Update()
    {
        RaycastPlayer();
    }

    void RaycastPlayer()
    {
        Vector3 origion = transform.position;
        Vector3 direction = transform.forward;
        
        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = colorChange;
            GetComponent<robotChase>().enabled = true;
            GetComponent<robotPatrol>().enabled = false;
            GetComponent<robotChase>().ResetTimer();

        }
        else
        {
            
            //if(GetComponent<robotChase>().chaseStop())
            //{
            //    GetComponent<Renderer>().material.color = colorOrigion;
            //    GetComponent<robotChase>().enabled = false;
            //    GetComponent<robotPatrol>().enabled = true;
            //}
           
        }
    }
}
