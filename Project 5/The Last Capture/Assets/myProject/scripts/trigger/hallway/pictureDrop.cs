using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictureDrop : MonoBehaviour
{
    [SerializeField] Animator animator_pictureDrop;
    //[SerializeField] Animator animator_pictureTest;

    [SerializeField] float time_toBreak = 3f;

    [SerializeField] AudioClip audio_break;
    [SerializeField] AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {
        //animator_pictureDrop = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator_pictureDrop.enabled = true;
            //animator_pictureTest.enabled = true;
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(time_toBreak);
        audioS.PlayOneShot(audio_break);
        Destroy(gameObject);
    }
}
