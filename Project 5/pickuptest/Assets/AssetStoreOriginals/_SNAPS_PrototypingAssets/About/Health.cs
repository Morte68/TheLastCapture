using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int HealthMax;
    public int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        HealthMax = 3;
        CurrentHealth = HealthMax;

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
            triggerEnd();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            CurrentHealth -= 1;
        }
        if (collision.gameObject.CompareTag("Fire"))
        {
            CurrentHealth -= 1;
        }
    }
    private void triggerEnd() {
        SceneManager.LoadScene(0);
    }
}
}
