using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public GameObject player;
    public string InteractionPrompt => prompt;

    public bool cooldown;

    public bool ComputerIsDone;
    public bool KitchenIsDone;
    public bool UrinalIsDone;
    public bool MeetingIsDone;
    public int Days = 1;

    public AudioSource audioSource;
    public AudioClip DaySound;

    public bool BossCheck;

    
    public GameObject BlackScreen;
    ScreenFade screenFade;
    public Animator animator;
    public Animator elevator;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Days == 2 )
        {
            //StartCoroutine(EndDay());
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (Days == 1)
        {
            if (BossCheck == true)
            {
                StartCoroutine(EndDay());
            }

        }

        return true;
    }


    IEnumerator EndDay()
    {
        if(cooldown == false)
        {
            Debug.Log("day end");
            player.transform.position = new Vector3(142, 7.4f, -43f);
            yield return new WaitForSeconds(2);
            elevator.SetTrigger("Elevator Close");
            animator.SetTrigger("Ftb");
            //play day end sound
            audioSource.PlayOneShot(DaySound);
            yield return new WaitForSeconds(14);
            Days++;
            animator.SetTrigger("fob");
            yield return new WaitForSeconds(3);
            elevator.SetTrigger("Elevator Open");
            cooldown = true;
        }
        
    }
}
