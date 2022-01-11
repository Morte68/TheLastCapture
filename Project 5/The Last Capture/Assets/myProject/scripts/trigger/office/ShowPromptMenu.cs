using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromptMenu : MonoBehaviour
{
    [SerializeField] GameObject prompt_menu;
    float time_showPrompt_menu = 5f;
    [SerializeField] GameObject menu;


    private void Update()
    {
        if (menu.GetComponent<Menu>().isClose == true)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowPrompt_menu());
        }

    }

    IEnumerator ShowPrompt_menu()
    {
        prompt_menu.SetActive(true);
        yield return new WaitForSeconds(time_showPrompt_menu);
        prompt_menu.SetActive(false);
        Destroy(gameObject);
    }
}
