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
            Debug.Log(MikeIsOpen);
            animator.SetTrigger("Microwave Open");
            audioSource.PlayOneShot(microwaveOpen, 0.7f);
           
        }

        if (MikeIsOpen == true)
        {
            Debug.Log(MikeIsOpen);
            audioSource.PlayOneShot(microwaveClosed, 0.7f);
            animator.SetTrigger("Microwave Close");
            StartCoroutine(MicroWaveWait());
            
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
                thebool = true;
                

            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
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
            kitchenGame.noodleStage = 2;
            kitchenObjs.GrabBool = false;
            yield return new WaitForSeconds(2);
            audioSource.PlayOneShot(cooking, 0.7f);
            animator.SetTrigger("Microwave Open");
            MikeIsOpen = false;
            kitchenGame.NoodlesIsDone = true;
            thebool = false;
            Mcollider.enabled = false;
            gameObject.layer = default;
        }
        
    }
}
