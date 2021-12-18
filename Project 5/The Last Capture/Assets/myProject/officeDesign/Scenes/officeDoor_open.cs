using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeDoor_open : MonoBehaviour
{
    [SerializeField] Animator animation_officeDoor_open;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            animation_officeDoor_open.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece 3"))
        {
            canMove = true;
            Destroy(collision.gameObject);
        }
    }
}
