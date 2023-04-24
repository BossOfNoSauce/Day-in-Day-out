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
    public AudioClip microwave;
    public Animator animator;

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
            if(other.gameObject.tag == "Noodles")
            {
                StartCoroutine(MicroWaveWait());
                // close door

            }
        }
    }

    IEnumerator MicroWaveWait()
    {
        kitchenGame.noodleStage = 2;
        kitchenObjs.GrabBool = false;
        yield return new WaitForSeconds(2);
        animator.SetBool("Microwave Open", true);
        kitchenGame.NoodlesIsDone = true;
    }
}
