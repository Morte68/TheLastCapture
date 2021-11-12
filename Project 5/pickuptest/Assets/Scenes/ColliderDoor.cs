using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDoor : MonoBehaviour
{
    public GameObject Door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece 3"))
        {
            Destroy(Door);
            Destroy(collision.gameObject);
        }
    }
}
