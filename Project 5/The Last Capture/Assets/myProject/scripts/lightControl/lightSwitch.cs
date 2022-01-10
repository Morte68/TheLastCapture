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

    [SerializeField] GameObject object_ceilingLight;
    //[SerializeField] Color colorOff;
    //[SerializeField] Color colorOn;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shinning());
        
        rend = object_ceilingLight.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Shinning()
    {
        timeRandom = Random.Range(timeMin, timeMax);
        yield return new WaitForSeconds(timeRandom);
        StartCoroutine(Blink());
        StartCoroutine(Shinning());
    }

    IEnumerator Blink()
    {
        GetComponent<Light>().enabled = false;
        rend.sharedMaterial.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(shine);
        GetComponent<Light>().enabled = true;
        rend.sharedMaterial.EnableKeyword("_EMISSION");
    }
}
