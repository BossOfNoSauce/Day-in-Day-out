using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour, Iinteractable
{
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

    public GameObject PauseMenu;
    PauseGame pauseGame;

    
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject DayManager;
    DaySystem daySystem;



    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        game();
        return true;
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
        if (targetMovement.GameOver || targetMovement.GameFail)//end game in here to check constantly
        {
            //these debugs fill the console
            //if (targetMovement.GameOver) Debug.Log("game end");
            //if (targetMovement.GameFail) Debug.Log("Game fail");
            // disables all previous variables, allowing normal movement
            noMovement = false;
            playerController.InGame = false;
            pauseGame.AbleToPause = true;
            audioSource.Stop();
        }
    }


    public void game()
    {
        playerController.InGame = true;
        //sets player to inGame, freezing them in place
        StartCoroutine(StartUrination());

       
    }

    IEnumerator StartUrination()
    {
        if (targetMovement.GameOver == false || targetMovement.GameFail == false)
        {
            pauseGame.AbleToPause = false; //dissables pause menu
            pauseGame.Paused();
            gameManager.gameActive = true;
            //add menu popup here
            menu.SetActive(true);
            targetMovement.GameIsActive = true; // this starts the target moving back and forth
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            noMovement = true; // this locks camera on the target
            Player.transform.position = new Vector3(82, 7.5f, 27f); // sets player in proper pissing position
            yield return new WaitForSeconds(10); // game timer
            targetMovement.GameOver = true;
        }
    }
}
