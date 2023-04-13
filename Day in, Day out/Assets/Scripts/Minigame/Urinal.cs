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

    
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;



    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        game();
        return true;
    }

    // Awake is called before the first frame update
    void Awake()
    {
        playerController = Player.GetComponent<PlayerMovement>();

        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();

        targetMovement = dipshitCube.GetComponent<TargetMovement>();

        gameManager = manager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void game()
    {
        playerController.InGame = true;
        StartCoroutine(StartUrination());
    }

    IEnumerator StartUrination()
    {
        if (targetMovement.GameOver == false || targetMovement.GameFail == false)
        {
            gameManager.gameActive = true;
            yield return new WaitForSeconds(3);
            targetMovement.GameIsActive = true;
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            noMovement = true;
            Player.transform.position = new Vector3(82, 7.5f, 27f);
            yield return new WaitForSeconds(21);
            noMovement = false;
            playerController.InGame = false;
            targetMovement.GameOver = true;
        }
       
    }

    void Freeze()
    {
        if (noMovement == false)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

           MainCam.transform.LookAt(target.transform.position, Vector3.up);





           
        }
    }
}
