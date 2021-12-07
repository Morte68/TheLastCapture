using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{

    [SerializeField] float timeMin = 0.5f;
    [SerializeField] float timeMax = 5f;
    //float timer;
    [SerializeField] float shine = 0.5f;
    float timeRandom;

    // Start is called before the first frame update
    void Start()
    {
        timeRandom = Random.Range(timeMin, timeMax);
        StartCoroutine(shinning());
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator shinning()
    {
        yield return new WaitForSeconds(timeRandom);
        GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(shine);
        GetComponent<Light>().enabled = true;
        timeRandom = Random.Range(timeMin, timeMax);
        StartCoroutine(shinning());
    }
}
