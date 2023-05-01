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

    public GameObject JukeBoxObj;
    Jukebox jukebox;

    public GameObject BlackScreen;
    ScreenFade screenFade;
    public Animator animator;

    public Animator elevator;

    public PlayerMovement playerMovement;

    public bool BossCooldown;

    // Start is called before the first frame update
    void Start()
    {
        jukebox = JukeBoxObj.GetComponent<Jukebox>();
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
        if (Days != 4)
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
            playerMovement.InGame = true;
            yield return new WaitForSeconds(3);
            elevator.SetTrigger("Elevator Close");
            animator.SetTrigger("Ftb");
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(DaySound);
            animator.SetTrigger("Ftb");
            yield return new WaitForSeconds(15);
            Days++;
            animator.SetTrigger("fob");
            yield return new WaitForSeconds(3);
            elevator.SetTrigger("Elevator Open");
            cooldown = true;
            jukebox.startMus = true;
            ComputerIsDone = false;
            if(Days == 2)
            {
                ComputerIsDone = false;
                UrinalIsDone = false;
            }
            if(Days == 3)
            {
                ComputerIsDone = false;
                KitchenIsDone = false;
            }
            if(Days == 4)
            {
                ComputerIsDone = false;
                MeetingIsDone = false;
            }
        }
        
    }
}
