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
    public Transform lamp;
    public eColor lightColor;
    Renderer rend;
    [SerializeField] float rayDistance = 2f;
    [SerializeField] GameObject panelScreen;
    //[SerializeField] GameObject prompt;

    [Header("VFX===================================")]
    [SerializeField] GameObject fireAmber;
    [SerializeField] GameObject smokeFire;

    [Header("Animation======================================")]
    [SerializeField] Animator animator_exitDoor;
    [SerializeField] Animator animator_robotControlRoom_door_close;
    [SerializeField] float time_countDown = 30f;
    [SerializeField] GameObject debris;
    public bool on;
    bool isOpened = false;
    bool isTimeStart_countDown = false;
    [SerializeField] Animator upSideDown;

    [Header("Audio===================================")]
    [SerializeField] float time_alarm = 3f;
    //[SerializeField] AudioClip audioC_buttonNotification;
    AudioSource audioS;
    [SerializeField] GameObject ambient_horror;

    [Header("Light======================")]
    [SerializeField] GameObject light_spotLightRotate;
    [SerializeField] Light exitLight;
    [SerializeField] float exitLight_intensity = 3f;

    [Header("UI===================================")]
    [SerializeField] GameObject prompt_startPower;
    [SerializeField] GameObject prompt_door;


    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
        rend = lamp.GetComponent<Renderer>();
        audioS = GetComponent<AudioSource>();
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
            //prompt.SetActive(true);
            prompt_startPower.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
        else
        {
            //prompt.SetActive(false);
            prompt_startPower.SetActive(false);
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
        //show panel screen count down timer message
        panelScreen.SetActive(true);

        //close the door in robot control room with a animation
        animator_robotControlRoom_door_close.SetBool("isClose", true);

        //start alarm light rotating
        light_spotLightRotate.SetActive(true);

        // play alarm sound
        StartCoroutine(PlayAlarm());

        //enable male robot picture animator to a upsidedown state
        upSideDown.enabled = true;

        //disable prompts
        prompt_startPower.SetActive(false);

        //disable exit door prompt
        prompt_door.GetComponent<DoorPrompt_office>().enabled = false;

        //disable ambient sounds in the hall way
        ambient_horror.SetActive(false);

        // brighten the exit sign
        exitLight.intensity = exitLight_intensity;

        smokeFire.SetActive(false);
        fireAmber.SetActive(true);
        robot.GetComponent<StateMachine>().setState((int)ERobotState.prepareProtect);
        GetComponent<FireSpreading>().enabled = true;
        isTimeStart_countDown = true;
        //prompt.SetActive(false);
        lightColor = eColor.Blue;
        isOpened = true;
        debris.SetActive(true);
    }

    IEnumerator PlayAlarm()
    {
        audioS.Play();
        yield return new WaitForSeconds(time_alarm);
        audioS.Pause();
    }
}
