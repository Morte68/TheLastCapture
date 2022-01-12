using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_robotChase : MonoBehaviour
{
    GameObject robot;

    [Header("Audio===================================")]
    [SerializeField] AudioClip lightning;
    [SerializeField] AudioClip horror;
    [SerializeField] AudioSource audioS;

    [Header("Light=====================================")]
    [SerializeField] GameObject light;
    [SerializeField] Renderer rend;
    //[SerializeField] Material white;
    //[SerializeField] Material black;

    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(robot == null)
                robot = GameObject.FindWithTag("Robot");

            StateMachine stateMachine = robot.GetComponent<StateMachine>();
            if (stateMachine == null)
                Debug.LogError("Failed To Find State Machine On Robot!");

            stateMachine.setState((int)ERobotState.Chase);
            audioS.PlayOneShot(lightning);
            StartCoroutine(light_shineOnce());
            audioS.PlayOneShot(horror);
        }

        IEnumerator light_shineOnce()
        {
            yield return new WaitForSeconds(0.4f);
            light.SetActive(true);
            rend.sharedMaterial.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.5f);
            light.SetActive(false);
            rend.sharedMaterial.DisableKeyword("_EMISSION");
            Destroy(gameObject);
        }
    }
}
