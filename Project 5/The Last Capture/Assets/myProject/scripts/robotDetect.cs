using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotDetect : MonoBehaviour
{
    [SerializeField] private float rayDistance = 50.0f;
    Color colorChange = Color.red;
    //  Vector3 origion = transform.position;
    //  Vector3 direction = transform.forward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastSingle();
    }

    void RaycastSingle()
    {
        Vector3 origion = transform.position;
        Vector3 direction = transform.forward;
        
        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject.CompareTag("Player"))
        {
            // raycastHit.collider.GetComponent<renderer>().material.color = colorChange;
            GetComponent<Renderer>().material.color = colorChange;
            GetComponent<robotNavMesh>().enabled = true;
            GetComponent<robotPatrol>().enabled = false;

            GetComponent<robotNavMesh>().ResetTimer();

        }
        else
        {
            if(GetComponent<robotNavMesh>().ShouldStopChasing())
            {
                GetComponent<robotNavMesh>().enabled = false;
                GetComponent<robotPatrol>().enabled = true;
            }
        }
    }
}
