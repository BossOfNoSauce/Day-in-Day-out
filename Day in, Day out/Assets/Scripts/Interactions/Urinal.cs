using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urinal : MonoBehaviour, Iinteractable
{
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void game()
    {
        //Set InGame bool to true

        //Move Camera into better position

        //waitforseconds startup time and tutorial text

        //game timer start

        //apply camera adjustments

        //end game

    }
}
