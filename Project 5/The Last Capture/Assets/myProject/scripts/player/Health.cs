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

    bool isStay_robot = false;
    bool isStay_fire = false;

    public bool isDamageable_robot = true;

    [SerializeField] GameObject deathNote;
    [SerializeField] GameObject player;

    [SerializeField] GameObject scream;
    [SerializeField] float time_scream = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = HealthMax;
        agent = GameObject.FindWithTag("Robot").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Staying();
        if (CurrentHealth <= 0) StartCoroutine(Death());
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot") && isDamageable_robot == true)
        {
            isStay_robot = true;
            VFX_collision.SetActive(true);
            CurrentHealth -= 1;
            StartCoroutine(RobotStop());
            StartCoroutine(Scream());
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            isStay_fire = true;
            CurrentHealth -= 1;
            StartCoroutine(Scream());
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
    void Staying()
    {
        if (isStay_robot == true)
        {
            time_waitForDamage += Time.deltaTime;
            if (time_waitForDamage >= time_waitForDamage_max)
            {
                CurrentHealth -= 1;
                StartCoroutine(RobotStop());
                StartCoroutine(Scream());

                time_waitForDamage = 0f;
            }
        }
        if(isStay_fire == true)
        {
            time_waitForDamage += Time.deltaTime;
            if (time_waitForDamage >= time_waitForDamage_max)
            {
                CurrentHealth -= 1;
                time_waitForDamage = 0f;
                StartCoroutine(Scream());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            CurrentHealth = 0;
            StartCoroutine(Scream());
        }
    }

    //void OnTriggerStay(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Robot"))
    //    {
    //        time_waitForDamage += Time.deltaTime;
    //        if (time_waitForDamage >= time_waitForDamage_max)
    //        {
    //            CurrentHealth -= 1;
    //            StartCoroutine(RobotStop());
    //            time_waitForDamage = 0f;
    //        }
    //    }
    //    else if (collision.gameObject.CompareTag("Fire"))
    //    {
    //        time_waitForDamage += Time.deltaTime;
    //        if (time_waitForDamage >= time_waitForDamage_max)
    //        {
    //            CurrentHealth -= 1;
    //            time_waitForDamage = 0f;
    //        }
    //    }
    //}

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot") && isDamageable_robot == true)
        {
            isStay_robot = false;
            time_waitForDamage = 0f;
            VFX_collision.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            isStay_fire = false;
            time_waitForDamage = 0f;

        }
    }

    // robot stop after collide with player
    IEnumerator RobotStop()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(time_robotStop);
        agent.enabled = true;
    }

    // player screaming sfx
    IEnumerator Scream()
    {
        scream.SetActive(true);
        yield return new WaitForSeconds(time_scream);
        scream.SetActive(false);
    }

    // player death screen and then restart the game
    IEnumerator Death()
    {
        deathNote.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
        deathNote.SetActive(false);
        player.SetActive(true);
    }
}
