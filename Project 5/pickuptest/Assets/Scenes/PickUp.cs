using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform theDest;

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().isKinematic = true;

        //this.transform.position = theDest.position;
        //this.transform.parent = GameObject.Find("Destination").transform;

        GetComponent<EnforceFollowParent>().transformToFollow = GameObject.Find("Destination").transform;
    }
   void OnMouseUp()
    {
        //this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        //GetComponent<Rigidbody>().isKinematic = false;

        GetComponent<EnforceFollowParent>().transformToFollow = null;

    }

    private void OnCollisionEnter(Collision collision)
    {
        int i = 0;
        //OnMouseUp();
    }
}
