using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public GameObject player;
    public string InteractionPrompt => prompt;

    public bool cooldown;
    //minigame bools, IsWin for fail / win state
    public bool ComputerIsDone;
    public bool computerIsWin;
    public bool KitchenIsDone;
    public bool kitchenIsWin;
    public bool UrinalIsDone;
    public bool urinalIsWin;
    public bool MeetingIsDone;
    public bool meetingIsWin;

    //day count
    public int Days = 1;
    //audio
    public AudioSource audioSource;
    public AudioClip DaySound;

    public AudioClip OpeningElevator;

    public bool BossCheck;
    public bool AbleToChase;
    public GameObject JukeBoxObj;
    Jukebox jukebox;

    public GameObject BlackScreen;
    ScreenFade screenFade;
    public Animator animator;

    public Animator elevator;

    public PlayerMovement playerMovement;

    public Computer computer;

    public KitchenObjs kitchenObjs;

    public bool BossCooldown;

    public GameObject ComputerTaskUi;
    public GameObject UrinalTaskUi;
    public GameObject KitchenTaskUi;
    public GameObject MeetingTaskUi;
    public GameObject BossTaskUi;

    // Start is called before the first frame update
    void Start()
    {
        ComputerTaskUi.SetActive(true);
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
            yield return new WaitForSeconds(2);
            animator.SetTrigger("Ftb");
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(DaySound); 
            yield return new WaitForSeconds(13);
            Days++;
            animator.SetTrigger("fob");
            yield return new WaitForSeconds(2);
            elevator.SetTrigger("Elevator Open");
            audioSource.PlayOneShot(OpeningElevator);
            cooldown = true;
            jukebox.startMus = true;
            ComputerIsDone = false;
            playerMovement.InGame = false;
            if (Days == 2)
            {
                
                computerIsWin = false;
                ComputerIsDone = false;
                computer.score = 0;
                UrinalIsDone = false;
                BossCooldown = false;
                UrinalTaskUi.SetActive(true);
            }
            if(Days == 3)
            {
                UrinalIsDone = false;
                ComputerIsDone = false;
                KitchenIsDone = false;
                kitchenObjs.ResetObjs();
                BossCooldown = false;
               KitchenTaskUi.SetActive(true);
            }
            if(Days == 4)
            {
                ComputerIsDone = false;
                MeetingIsDone = false;
                KitchenIsDone = false;
                kitchenObjs.ResetObjs();
                UrinalIsDone = false;
                BossCooldown = false;
                MeetingTaskUi.SetActive(true);
            }
            if (Days == 5)
            {
                AbleToChase = true;
                jukebox.StopMus();
                jukebox.startMus = false;
                ComputerIsDone = true;
                MeetingIsDone = true;
                KitchenIsDone = true;
                kitchenObjs.ResetObjs();
                UrinalIsDone = true;
                

            }

        }
        
    }
}
