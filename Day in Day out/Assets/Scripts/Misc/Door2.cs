using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour, Iinteractable
{
    public AudioSource audioSource;
   
    public AudioClip locked;

    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;
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
         audioSource.PlayOneShot(locked, 0.7f);
           
        return true;
    }
}
