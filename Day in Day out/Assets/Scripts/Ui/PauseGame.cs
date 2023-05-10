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
    public AudioSource BossaudioSource;
    public AudioSource Music;
    public bool AbleToPause = true;
    public bool menuActive = false;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public void Paused()
    {
        Debug.Log("pauseing");
        if(AbleToPause == true)
        {
            Time.timeScale = 0f;
            firstPersonCameraRotation.FreezeMovement = true;
            pauseMenu.SetActive(true);
            cursor.SetActive(true);
            audioSource.Pause();
            Music.Pause();
            BossaudioSource.Pause();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
    }
    public void simPaused()
    {
        Debug.Log("simple pause");
        Time.timeScale = 0f;
        cursor.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void Resume()
    {
        Debug.Log("resuming");
       if(AbleToPause == true)
        {
            Time.timeScale = 1.0f;
            firstPersonCameraRotation.FreezeMovement = false;
            pauseMenu.SetActive(false);
            audioSource.UnPause();
            BossaudioSource.UnPause();
            Music.UnPause();
            cursor.SetActive(false);


            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
    }
    public void simResume()
    {
        Debug.Log("simple resume");
        cursor.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
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
        if (Input.GetKeyDown(KeyCode.P))
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
