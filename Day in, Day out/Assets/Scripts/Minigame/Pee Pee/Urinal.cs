using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour, Iinteractable
{
    PlayerMovement playerController;

    public GameObject manager;
    GameManager gameManager;


    public GameObject Player;
    //player is needed so it can get da script
    TargetMovement targetMovement;
    public GameObject dipshitCube;
    PlayerCam playerCam;
    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;
    public GameObject target;
    //public GameObject target;
    public bool noMovement = false;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

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

        targetMovement = dipshitCube.GetComponent<TargetMovement>();

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

    IEnumerator StartUrination()
    {
        if (targetMovement.GameOver == false || targetMovement.GameFail == false)
        {
            pauseGame.AbleToPause = false; // disables pausing
            gameManager.gameActive = true; 
            yield return new WaitForSeconds(3); // tutorial time
            targetMovement.GameIsActive = true; // this starts the target moving back and forth
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            noMovement = true; // this locks camera on the target
            Player.transform.position = new Vector3(82, 7.5f, 27f); // sets player in proper pissing position
            yield return new WaitForSeconds(21); // game timer
           // disables all previous variables, allowing normal movement
            noMovement = false; 
            playerController.InGame = false;
            targetMovement.GameOver = true;
            pauseGame.AbleToPause = true;
            daySystem.UrinalIsDone = true;
        }
       
    }

    void Freeze()
    {
        
    }
}
