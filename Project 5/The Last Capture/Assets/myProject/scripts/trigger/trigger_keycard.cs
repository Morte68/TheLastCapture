using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger_keycard : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject prompt;
    [SerializeField] Text prompt_keycardAccess;
    [SerializeField] float rayDistance = 1f;
    GameObject playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 1f && PlayerRay())
        {
            prompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                prompt.SetActive(false);
                prompt_keycardAccess.text = "Press \"F\" to use the keycard!";
                gameObject.SetActive(false);
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
