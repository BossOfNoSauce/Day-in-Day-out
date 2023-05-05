using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    
    [SerializeField] private string prompt;
    public bool thebool;
    public string InteractionPrompt => prompt;
    public AudioSource audioSource;
    public AudioClip door;
    public AudioClip locked;
    public Animator animator;

    public bool canOpen;
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
        if(thebool == false)
        {
            
            animator.SetTrigger("Interact");
            if (canOpen)
            {
                audioSource.PlayOneShot(door, 0.7f);
            }
            else
            {
                audioSource.PlayOneShot(locked, 0.7f);
            }
            
            thebool = true;
        }
        return true;
    }

}

