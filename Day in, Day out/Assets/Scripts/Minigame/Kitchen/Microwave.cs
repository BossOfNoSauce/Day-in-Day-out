using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour, Iinteractable
{
    public GameObject Kitchen;
     KitchenGame kitchenGame;

    [SerializeField] private string prompt;
    public bool thebool;
    public string InteractionPrompt => prompt;
    public AudioSource audioSource;
    public AudioClip microwaveOpen;
    public AudioClip microwaveClosed;
    public Animator animator;

    public bool MikeIsOpen = false;

    public GameObject noodles;
    KitchenObjs kitchenObjs;

    
    void Start()
    {
        kitchenGame = Kitchen.GetComponent<KitchenGame>();
        kitchenObjs = noodles.GetComponent<KitchenObjs>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if (MikeIsOpen == false)
        {
            Debug.Log(MikeIsOpen);
            //animator.SetBool("Microwave Open", true);
            audioSource.PlayOneShot(microwaveOpen, 0.7f);
           // MikeIsOpen = true;
        }

        if (MikeIsOpen == true)
        {
            Debug.Log(MikeIsOpen);
            audioSource.PlayOneShot(microwaveClosed, 0.7f);
            //animator.SetBool("Microwave Open", true);
            StartCoroutine(MicroWaveWait());
            
        }
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
        {
            if(other.gameObject.tag == "Noodles")
            {
                thebool = true;
                // close door

            }
        }
    }

    IEnumerator MicroWaveWait()
    {
        if(thebool == true)
        {
            kitchenGame.noodleStage = 2;
            kitchenObjs.GrabBool = false;
            yield return new WaitForSeconds(2);
            animator.SetBool("Microwave Open", true);
            MikeIsOpen = false;
            kitchenGame.NoodlesIsDone = true;
        }
        
    }
}
