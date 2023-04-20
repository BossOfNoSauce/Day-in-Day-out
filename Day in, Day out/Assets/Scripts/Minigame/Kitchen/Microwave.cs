using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour, Iinteractable
{
    public GameObject Kitchen;
    public KitchenGame kitchenGame;

    [SerializeField] private string prompt;
    public bool thebool;
    public string InteractionPrompt => prompt;
    public AudioSource audioSource;
    public AudioClip microwave;
    public Animator animator;
    
    void Start()
    {
        kitchenGame = Kitchen.GetComponent<KitchenGame>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if (thebool == false)
        {
            audioSource.PlayOneShot(microwave, 0.7f);
            animator.SetBool("Microwave Open",true);
            thebool = true;
        }
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
        {

        }
    }

}
