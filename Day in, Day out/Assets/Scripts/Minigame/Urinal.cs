using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour, Iinteractable
{
    PlayerMovement playerController;
    
    public GameObject Player;
    //player is needed so it can get da script

    PlayerCam playerCam;
    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    //public GameObject target;

    public AudioSource audioSource;
    public AudioClip pissmusic;

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
        Debug.Log("boutta piss");
        yield return new WaitForSeconds(3);
        audioSource.PlayOneShot(pissmusic, 0.7F);
        playerController.DummyFunc();
        firstPersonCameraRotation.noMovement = true;
        Debug.Log(playerController.InGame);
        if (playerController.InGame == false)
        {
            firstPersonCameraRotation.noMovement = false;
        }
        // the text
    }
}
