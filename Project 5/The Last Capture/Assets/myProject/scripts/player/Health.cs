using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Health : MonoBehaviour
{
    public int HealthMax = 3;
    public int CurrentHealth;
    NavMeshAgent agent;
    public float time_robotStop = 1f;
    [SerializeField] GameObject VFX_collision;
    [SerializeField] float time_waitForDamage = 0f;
    [SerializeField] float time_waitForDamage_max = 5f;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = HealthMax;
        agent = GameObject.FindWithTag("Robot").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
            triggerEnd();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
        VFX_collision.SetActive(true);
            CurrentHealth -= 1;
            StartCoroutine(RobotStop());
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            CurrentHealth -= 1;
        }
        //switch(collision)
        //{
        //    case collision.gameObject.CompareTag("Robot"):
        //        CurrentHealth -= 1;
        //        StartCoroutine(RobotStop());
        //        break;
        //    case collision.gameObject.CompareTag("Fire"):
        //        CurrentHealth -= 1;
        //        break;
        //}
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            time_waitForDamage += Time.deltaTime;
            if (time_waitForDamage >= time_waitForDamage_max)
            {
                CurrentHealth -= 1;
                StartCoroutine(RobotStop());
                time_waitForDamage = 0f;
            }
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            time_waitForDamage += Time.deltaTime;
            if (time_waitForDamage >= time_waitForDamage_max)
            {
                CurrentHealth -= 1;
                time_waitForDamage = 0f;
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            time_waitForDamage = 0f;
            VFX_collision.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            time_waitForDamage = 0f;

        }
    }
    private void triggerEnd()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator RobotStop()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(time_robotStop);
        agent.enabled = true;
    }
}
