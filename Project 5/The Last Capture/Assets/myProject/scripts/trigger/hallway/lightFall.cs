using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFall : MonoBehaviour
{
    [SerializeField] Animator lightFallDown;
    [SerializeField] GameObject shine;

    [SerializeField] float time_toBreak = 3f;

    [SerializeField] AudioClip audio_break;
    [SerializeField] AudioSource audioS;


    //private void Start()
    //{
    //    audioS = GetComponent<AudioSource>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            lightFallDown.enabled = true;
            StartCoroutine(Break());
            //if (lightFallDown.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
            //{
                shine.GetComponent<lightSwitch>().enabled = true;
            //}
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(time_toBreak);
        audioS.PlayOneShot(audio_break);
        Destroy(gameObject);
    }
}
