using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject menu;
    //public AudioListener audioListener;
    [SerializeField] GameObject cursor_inGame;
    [SerializeField] GameObject player;
    [SerializeField] GameObject camera_menu;

    [Header("UI============================================")]
    [SerializeField] GameObject prompt_menu;
    public bool isClose = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //show menu when pressing escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        showCursor();
        Time.timeScale = 0;
        menu.SetActive(true);
        isPause = true;
        //audioListener.enabled = false;
        player.SetActive(false);
        camera_menu.SetActive(true);
        //prompt_menu.SetActive(false);
        prompt_menu.GetComponent<Text>().text = "Press \"Escape\" to close menu";
    }

    public void Resume()
    {
        hideCursor();
        Time.timeScale = 1;
        menu.SetActive(false);
        isPause = false;
        //audioListener.enabled = true;
        cursor_inGame.SetActive(true);
        player.SetActive(true);
        camera_menu.SetActive(false);
        prompt_menu.SetActive(false);
        isClose = true;
    }

    public void restart()
    {
        Time.timeScale = 1;
        isPause = false;
        SceneManager.LoadScene("Project5");

        Debug.Log("restart from menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("quit from menu");
    }

    void showCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        cursor_inGame.SetActive(false);

    }

    void hideCursor()
    {
        Cursor.visible = false;
        cursor_inGame.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
