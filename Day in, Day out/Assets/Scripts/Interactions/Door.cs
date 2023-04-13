using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public Animator animator;
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
        animator.SetTrigger("Interact");
        return true;
    }

}

