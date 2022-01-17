using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_robotChase : MonoBehaviour
{
    GameObject robot = null;
    StateMachine stateMachine = null;

    [Header("Audio===================================")]
    [SerializeField] AudioClip lightning;
    [SerializeField] AudioClip horror;
    [SerializeField] AudioSource audioS;

    [Header("Light=====================================")]
    [SerializeField] GameObject light;
    [SerializeField] Renderer rend;
    //[SerializeField] Material white;
    //[SerializeField] Material black;

    [Header("Animator======================================")]
    [SerializeField] Animator door;

    void Start()
    {
        var listOfObjects = GameObject.FindGameObjectsWithTag("Robot");
        for (int i = 0; i < listOfObjects.Length; ++i)
        {
            var stateMachineTempVariable = listOfObjects[i].GetComponent<StateMachine>();
            if (stateMachineTempVariable != null)
            {
                robot = listOfObjects[i];
                stateMachine = stateMachineTempVariable;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
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
            door.SetBool("isOpen", true);
            Destroy(gameObject);
        }
    }
}
