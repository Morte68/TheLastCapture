using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpreading : MonoBehaviour
{
    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Fire4;
    public GameObject Fire5;
    public GameObject Fire6;
    public GameObject Fire7;
    public GameObject Fire8;
    public GameObject Fire9;
    public GameObject Fire10;
    public GameObject Fire11;
    public GameObject Fire12;
    public GameObject Fire13;
    public GameObject Fire14;
    public GameObject Fire15;
    public GameObject Fire16;
    public GameObject Fire17;
    public GameObject Fire18;
    public GameObject Fire19;
    public GameObject Fire20;
    public GameObject Fire21;
    //public GameObject Fire22;
    public GameObject fireMove;
    public float FireWaitTime;
    void Start()
    {
        fireMove.SetActive(true);
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(FireSpreadCoroutine());
    }

    IEnumerator FireSpreadCoroutine()
    {
        Fire1.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire2.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire3.SetActive(true);
        Fire6.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire5.SetActive(true);
        Fire7.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire4.SetActive(true);
        Fire8.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire1.SetActive(false);
        Fire2.SetActive(false);
        Fire3.SetActive(false);
        Fire6.SetActive(false);
        Fire9.SetActive(true);
        Fire10.SetActive(true);
        yield return new WaitForSeconds(FireWaitTime);
        Fire5.SetActive(false);
        Fire7.SetActive(false);
        Fire11.SetActive(true);
        Fire12.SetActive(true);
        Fire13.SetActive(true);
        Fire14.SetActive(true);
        Fire15.SetActive(true);
        Fire16.SetActive(true);
        Fire17.SetActive(true);
        Fire18.SetActive(true);
        Fire19.SetActive(true);
        Fire20.SetActive(true);
        Fire21.SetActive(true);
        //yield return new WaitForSeconds(10f);
        //Fire22.SetActive(true);
    }
}
