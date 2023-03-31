using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour, Iinteractable
{
    PlayerMovement playerController;
    
    public GameObject Player;
    //player is needed so it can get da script
    TargetMovement targetMovement;
    public GameObject dipshitCube;
    PlayerCam playerCam;
    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    //public GameObject target;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;



    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("im taking a peeesss");
        game();
        return true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerController = Player.GetComponent<PlayerMovement>();

        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();

        targetMovement = dipshitCube.GetComponent<TargetMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void game()
    {
        playerController.InGame = true;

        //Move Camera into better position (maybe)

        StartCoroutine(StartUrination());

        

        //apply camera adjustments

        //end game

    }

    IEnumerator StartUrination()
    {
        
        yield return new WaitForSeconds(3);
        targetMovement.GameIsActive = true;
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        firstPersonCameraRotation.noMovement = true;
        yield return new WaitForSeconds(21);
        firstPersonCameraRotation.noMovement = false;
        playerController.InGame = false;
        targetMovement.GameOver = true;
        
        // the text
    }
}
