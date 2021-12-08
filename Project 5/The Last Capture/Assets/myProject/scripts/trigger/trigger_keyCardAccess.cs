using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_keyCardAccess : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject prompt;
    [SerializeField] float rayDistance = 2f;
    GameObject playerCamera;
    [SerializeField] GameObject keycard;
    [SerializeField] Material keycardAccess_open;
    Renderer rend;
    bool isOpened = false;
    //[SerializeField] Script Trigger_keycardAccess;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("PlayerCamera");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 2f && PlayerRay())
        {
            if(Input.GetKeyDown(KeyCode.F) && keycard.activeInHierarchy == false)
            {
                prompt.SetActive(false);
                rend.sharedMaterial = keycardAccess_open;
                //GetComponent<Trigger_keyCardAccess>().enabled = false;
                isOpened = true;
            }

            if(isOpened == false)
            {
                prompt.SetActive(true);
            }
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
