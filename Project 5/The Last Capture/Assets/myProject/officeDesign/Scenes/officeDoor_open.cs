using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeDoor_open : MonoBehaviour
{
    [SerializeField] Animator animation_officeDoor_open;
    AudioSource audioS;
    [SerializeField] AudioClip audioC_doorOpening;
    //bool canMove = false;
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject prompt_officeDoor;


    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (canMove == true)
        //{
            
        //}
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece 3"))
        {
            prompt.GetComponent<DoorPrompt_office>().enabled = false;
            prompt_officeDoor.SetActive(false);
            audioS.PlayOneShot(audioC_doorOpening);
            //audioS.enabled = true;
            animation_officeDoor_open.enabled = true;
            //canMove = true;
            Destroy(collision.gameObject);
        }
    }
}
