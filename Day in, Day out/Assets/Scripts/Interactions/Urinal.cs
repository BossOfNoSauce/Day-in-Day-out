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
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void game()
    {
        playerController.InGame = true;

        //Move Camera into better position (maybe)

        //waitforseconds startup time and tutorial text

        //game timer start

        //apply camera adjustments

        //end game

    }
}
