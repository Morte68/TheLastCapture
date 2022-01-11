using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrompt_office : MonoBehaviour
{
    GameObject player;
    GameObject playerCamera;

    [Header("******UI******")]
    [SerializeField] GameObject prompt;

    [Header("******Number******")]
    [SerializeField] float rayDistance = 1f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f && PlayerRay())
        {
            prompt.SetActive(true);
        }
        else
        {
            prompt.SetActive(false);
        }
    }

    bool PlayerRay()
    {
        Vector3 origion = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;

        Debug.DrawRay(origion, direction * rayDistance, Color.red);
        Ray ray = new Ray(origion, direction);
        RaycastHit raycastHit;
        return Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject;
    }
}
