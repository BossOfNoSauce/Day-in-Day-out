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

    public bool microOpen = true;

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
        if (microOpen)
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);
        }
        else
        {
            animator.SetBool("open", false);
            animator.SetBool("close", true);
        }
    }

    public bool Interact(Interactor interactor)
    {
        
        
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
        {
            if(other.gameObject.tag == "Noodles")
            {
                Debug.Log("closing microwave and starting");
                microOpen = false;
                gameObject.layer = default;
                thebool = true;
                kitchenObjs.simDrop();
                StartCoroutine(MicroWaveWait());

            }
        }
    }

    /*public void OnTriggerExit(Collider other)
    {
        if (kitchenGame.noodleStage == 1)
        {
            if (other.gameObject.tag == "Noodles")
            {
                Mcollider.enabled = true;
                gameObject.layer = LayerMask.NameToLayer("Interact");
            }
        }
    }*/

    IEnumerator MicroWaveWait()
    {
        if(thebool == true)
        {
            kitchenObjs.AbleToGrab = false;
            animator.SetBool("open", true);
            audioSource.PlayOneShot(microwaveClosed, 0.7f);
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(cooking, 0.7f);
            yield return new WaitForSeconds(13);
            microOpen = true;
            kitchenGame.noodleStage = 2;
            
            thebool = false;
            Mcollider.enabled = false;
            kitchenObjs.AbleToGrab = true;
            
            
        }
        
    }
    public void resetmicro()
    {
        Mcollider.enabled = true;
    }
}
