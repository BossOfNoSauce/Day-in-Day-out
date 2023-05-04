using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Urinal : MonoBehaviour, Iinteractable
{
    //to-do:
    //[]put some comments to describe stuff
    //[]
    PlayerMovement playerController;

    public GameObject manager;
    GameManager gameManager;


    public GameObject Player;//gets payer script
    TargetMovement targetMovement;
    PlayerCam playerCam;
    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;
    public GameObject target;
    //public GameObject target;
    public bool noMovement = false;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject menu;
    //ui
    public GameObject urinalUI;
    public GameObject urinalCheck;

    public GameObject PauseMenu;
    PauseGame pauseGame;

    
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject DayManager;
    DaySystem daySystem;



    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        if (targetMovement.GameOver || targetMovement.GameFail)//so that cant start game again
        {
            return false;
        }
        else
        {
            Debug.Log("stating game");
            game();
            return true;
        }
    }

    // Awake is called before the first frame update
    void Awake()
    {
        daySystem = DayManager.GetComponent<DaySystem>();

        pauseGame = PauseMenu.GetComponent<PauseGame>();

        playerController = Player.GetComponent<PlayerMovement>();

        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();

        targetMovement = target.GetComponent<TargetMovement>();

        gameManager = manager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (noMovement == true)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            MainCam.transform.LookAt(target.transform.position, Vector3.up);
        }
    }


    public void game()
    {
        playerController.InGame = true;
        //sets player to inGame, freezing them in place
        StartCoroutine(StartUrination());

       
    }
    public void endGame()
    {
        if (targetMovement.GameOver)//end game in here, constantly called
        {
            //setting bools
            daySystem.UrinalIsDone = true;
            daySystem.urinalIsWin = !targetMovement.GameFail;
            Image temp = urinalCheck.GetComponent<Image>();//from todo list, to set the check
            temp.color = (!targetMovement.GameFail ? new Color32(0, 255, 0, 100) : new Color32(255, 0, 0, 100));//if game is win, set image to green, else red

            // disables all previous variables, allowing normal movement
            firstPersonCameraRotation.FreezeMovement = false;
            noMovement = false;
            playerController.InGame = false;
            pauseGame.AbleToPause = true;
            audioSource.Stop();
        }
    }

    IEnumerator StartUrination()
    {
        if (targetMovement.GameOver == false)
        {
            if(daySystem.UrinalIsDone == false)
            {
                //urinalUI.SetActive(true);
                firstPersonCameraRotation.FreezeMovement = true;
                pauseGame.AbleToPause = false; //dissables pause menu
                pauseGame.simPaused();
                menu.SetActive(true);//tutorial menu
                Player.transform.position = new Vector3(82, 7.5f, 27f); // sets player in proper pissing position
                targetMovement.GameIsActive = true; // this starts the target moving back and forth
                audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
                audioSource.Play();
                noMovement = true; // this locks camera on the target
                yield return new WaitForSeconds(20); // game timer
                targetMovement.GameOver = true;
                daySystem.urinalIsWin = true;
                Debug.Log("done pissing");
                endGame();
            }
            
        }
    }
}
