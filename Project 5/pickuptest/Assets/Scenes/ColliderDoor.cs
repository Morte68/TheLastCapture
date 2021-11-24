using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDoor : MonoBehaviour
{
    public GameObject Door;
    public bool CanMove = false;
    public float MovementSpeed = 5;
    private Vector3 MaxHeight;

    private void Start()
    {
        MaxHeight = transform.position + GetComponent<Collider>().bounds.extents*2;
    }
    private void Update()
    {
        if (CanMove){ 
        Door.transform.position += new Vector3(0, MovementSpeed * Time.deltaTime, 0);

            if (transform.position.y > MaxHeight.y)
            {
                CanMove = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece 3"))
        {
            CanMove = true;
            Destroy(collision.gameObject);
        }
    }
}
