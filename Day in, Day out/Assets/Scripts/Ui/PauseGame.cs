using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject MainCam;
    public GameObject manager;
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
            Cursor.visible = true;
            audioSource.Pause();
        }
    }
    public void simPaused()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    public void Resume()
    {
       if(AbleToPause == true)
        {
            Time.timeScale = 1.0f;
            firstPersonCameraRotation.FreezeMovement = false;
            pauseMenu.SetActive(false);
            audioSource.UnPause();
            Cursor.visible = false;
        }
    }
    public void simResume()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
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
