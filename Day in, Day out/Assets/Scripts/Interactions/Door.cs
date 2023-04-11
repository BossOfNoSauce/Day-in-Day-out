using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{


    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        anim.Play("Door Open");
        return true;
    }

}

