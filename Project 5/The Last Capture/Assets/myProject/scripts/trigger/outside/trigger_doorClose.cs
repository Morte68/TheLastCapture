using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_doorClose : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] GameObject block_back;

    [Header("Animation================================")]
    [SerializeField] Animator doorClose;

    [Header("VFX==========================================")]
    [SerializeField] GameObject endFire;
    [SerializeField] float time_endFire = 14.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Closing());
        }
    }

    IEnumerator Closing()
    {
        block.SetActive(true);
        block_back.SetActive(true);
        endFire.SetActive(true);
        yield return new WaitForSeconds(time_endFire);
        doorClose.SetBool("isClose", true);
        block_back.SetActive(false);
        Destroy(gameObject);
    }
}
