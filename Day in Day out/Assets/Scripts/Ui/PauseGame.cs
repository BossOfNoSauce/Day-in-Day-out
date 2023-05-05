using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject MainCam;
    public GameObject manager;
    public GameObject cursor;
    GameManager gameManager;

    public AudioSource audioSource;

    public bool AbleToPause = true;
    public bool menuActive = false;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public void Paused()
    {
        
        if(AbleToPause == true)
        {
            Time.timeScale = 0f;
            firstPersonCameraRotation.FreezeMovement = true;
            pauseMenu.SetActive(true);
            cursor.SetActive(true);
            audioSource.Pause();
        }
    }
    public void simPaused()
    {
        Time.timeScale = 0f;
        cursor.SetActive(true);
    }
    public void Resume()
    {
       if(AbleToPause == true)
        {
            Time.timeScale = 1.0f;
            firstPersonCameraRotation.FreezeMovement = false;
            pauseMenu.SetActive(false);
            audioSource.UnPause();
            cursor.SetActive(false);
        }
    }
    public void simResume()
    {
        cursor.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        
        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();
        gameManager = manager.GetComponent<GameManager>();
    }
    //Pauses and unpauses game on escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActive = !menuActive;
            if (menuActive == true)
            {
                Paused();
            }
            if (menuActive == false)
            {
                Resume();
            }
        }
    }
}
