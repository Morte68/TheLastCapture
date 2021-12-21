using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLamp : MonoBehaviour
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
    //[SerializeField] GameObject[] VFX;
    [SerializeField] Animator protectionGlassClose;
    public Transform lamp;
    public eColor lightColor;
    Renderer rend;
    [SerializeField] float rayDistance = 2f;
    public bool on;
    bool isOpened = false;

    [SerializeField] Animator roboticArm;
    [SerializeField] float time_roboticArmStart = 4f;
    //[SerializeField] float time_VFX_0 = 1f;
    //[SerializeField] float time_VFX_1 = 1f;
    //[SerializeField] float time_VFX_2 = 1f;
    //bool hasLaunchedIEnumerator = false;


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

    IEnumerator roboticArmWait()
    {
        yield return new WaitForSeconds(time_roboticArmStart);
            roboticArm.enabled = true;
        //hasLaunchedIEnumerator = true;
    }

    public void Interact()
    {
        robot.GetComponent<StateMachine>().setState((int)ERobotState.goToChangePoint);
        protectionGlassClose.enabled = true;
        StartCoroutine(roboticArmWait());
        prompt.SetActive(false);
        lightColor = eColor.Green;
        isOpened = true;
    }
}
