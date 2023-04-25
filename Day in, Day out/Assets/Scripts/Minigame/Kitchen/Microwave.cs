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
    public AudioClip cooking;
    public Animator animator;

    public bool MikeIsOpen = false;

    public GameObject noodles;
    KitchenObjs kitchenObjs;

    public Collider Mcollider;
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
            Mcollider.enabled = true;
            
            animator.SetTrigger("Microwave Open");
            audioSource.PlayOneShot(microwaveOpen, 0.7f);
           
        }

        if (MikeIsOpen == true)
        {
            
            audioSource.PlayOneShot(microwaveClosed, 0.7f);
            animator.SetTrigger("Microwave Close");
            
            
        }
        MikeIsOpen = !MikeIsOpen;
        
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
        {
            if(other.gameObject.tag == "Noodles")
            {
                MikeIsOpen = false;
                gameObject.layer = default;
                thebool = true;
                kitchenObjs.GrabBool = false;
                kitchenObjs.RB.useGravity = !kitchenObjs.RB.useGravity;
                StartCoroutine(MicroWaveWait());

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (kitchenGame.noodleStage == 2)
        {
            if (other.gameObject.tag == "Noodles")
            {
                
                
                animator.SetTrigger("Microwave Closed");
                Mcollider.enabled = true;
                gameObject.layer = LayerMask.NameToLayer("Interact");
               

            }
        }
    }

    IEnumerator MicroWaveWait()
    {
        if(thebool == true)
        {
            kitchenObjs.AbleToGrab = false;
            animator.SetTrigger("Microwave Close");
            audioSource.PlayOneShot(microwaveClosed, 0.7f);
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(cooking, 0.7f);
            yield return new WaitForSeconds(13);
            kitchenGame.noodleStage = 2;
            animator.SetTrigger("Microwave Open");
            MikeIsOpen = false;
            kitchenGame.NoodlesIsDone = true;
            thebool = false;
            Mcollider.enabled = false;
            kitchenObjs.AbleToGrab = true;
            
            
        }
        
    }
}
