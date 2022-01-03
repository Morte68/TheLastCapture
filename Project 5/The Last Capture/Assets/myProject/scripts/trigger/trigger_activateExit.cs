using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class trigger_activateExit : MonoBehaviour
{
    public enum eColor
    {
        Red,
        Yellow,
        Green,
        Blue,
    }

    GameObject player;
    GameObject playerCamera;
    GameObject robot;
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject fireAmber;
    public Transform lamp;
    public eColor lightColor;
    Renderer rend;
    [SerializeField] Animator animator_exitDoor;
    [SerializeField] float rayDistance = 2f;
    [SerializeField] float time_countDown = 30f;
    public bool on;
    bool isOpened = false;
    bool isTimeStart_countDown = false;

    [SerializeField] GameObject debris;

    [SerializeField] GameObject smokeFire;


    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
        rend = lamp.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeStart_countDown == true)
        {
            time_countDown -= Time.deltaTime;
            
                if(time_countDown <= 0)
                {
                animator_exitDoor.enabled = true;
                animator_exitDoor.SetBool("character_nearby", true);
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= 2f && PlayerRay() && isOpened == false)
        {
            prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
        else
        {
            prompt.SetActive(false);
        }

        if (on)
        {
            switch (lightColor)
            {
                case eColor.Red:
                    rend.material.SetColor("_EmissionColor", new Color(1f, 0f, 0.02f, 1f));
                    break;
                case eColor.Yellow:
                    rend.material.SetColor("_EmissionColor", new Color(1f, 0.65f, 0f, 1f));
                    break;
                case eColor.Green:
                    rend.material.SetColor("_EmissionColor", new Color(0.15f, 1f, 0f, 1f));
                    break;
                case eColor.Blue:
                    rend.material.SetColor("_EmissionColor", new Color(0f, 0.33f, 1f, 1f));
                    break;
                default:
                    break;
            }

        }
        else
        {
            rend.material.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f, 0.0f));
        }
    }

    bool PlayerRay()
    {
        Vector3 origin = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
        Ray ray = new Ray(origin, direction);
        RaycastHit raycastHit;
        return Physics.Raycast(ray, out raycastHit, rayDistance) && raycastHit.collider.gameObject;
    }

    public void Interact()
    {
        smokeFire.SetActive(false);
        fireAmber.SetActive(true);
        robot.GetComponent<StateMachine>().setState((int)ERobotState.prepareProtect);
        GetComponent<FireSpreading>().enabled = true;
        isTimeStart_countDown = true;
        prompt.SetActive(false);
        lightColor = eColor.Blue;
        isOpened = true;
        debris.SetActive(true);
    }
}
