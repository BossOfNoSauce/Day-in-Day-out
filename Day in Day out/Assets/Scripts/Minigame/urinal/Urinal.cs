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

    public GameObject button;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject DayManager;
    DaySystem daySystem;



    public bool Interact(Interactor interactor)
    {
        button.SetActive(false);
        //this is what happenes when you interact
        if (daySystem.urinalIsWin || daySystem.UrinalIsDone)//so that cant start game again
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

        button.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       // these two lines of code sent the target all the way through the wall. i dont know why. god is dead and this fucked up code killed him
       // targetMovement.GameFail = daySystem.UrinalIsDone;
       // targetMovement.GameOver = daySystem.urinalIsWin;

        if (noMovement == true)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            MainCam.transform.LookAt(target.transform.position, Vector3.up);
        }

        if(daySystem.Days >= 2)
        {
            if(daySystem.UrinalIsDone == false)
            {
                button.SetActive(true);
            }
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
        if (daySystem.urinalIsWin)//end game in here, constantly called
        {
            //setting bools
            daySystem.UrinalIsDone = true;
            //daySystem.urinalIsWin = !targetMovement.GameFail;
            Image temp = urinalCheck.GetComponent<Image>();//from todo list, to set the check
            temp.color = (!daySystem.UrinalIsDone ? new Color32(0, 255, 0, 100) : new Color32(255, 0, 0, 100));//if game is win, set image to green, else red

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
                
                daySystem.urinalIsWin = true;
                Debug.Log("done pissing");
                endGame();
            }
            
        
    }
}
