using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Health : MonoBehaviour
{
    public int HealthMax;
    public int CurrentHealth;
    NavMeshAgent agent;
    public float time_robotStop;
    // Start is called before the first frame update
    void Start()
    {
        HealthMax = 3;
        CurrentHealth = HealthMax;
        agent = GameObject.FindWithTag("Robot").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
            triggerEnd();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            CurrentHealth -= 1;
            StartCoroutine(RobotStop());
        }
        if (collision.gameObject.CompareTag("Fire"))
        {
            CurrentHealth -= 1;
        }
    }
    private void triggerEnd() {
        SceneManager.LoadScene(0);
    }

    IEnumerator RobotStop()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(time_robotStop);
        agent.enabled = true;
    }
}
