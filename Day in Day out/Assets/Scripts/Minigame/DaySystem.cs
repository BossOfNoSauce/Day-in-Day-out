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
    //game scripts, for reseting purpuses
    public Computer computer;



    public KitchenObjs kitchenObjs;

    public bool BossCooldown;

    public GameObject ToDoList;
    
    //todo list ui elements
    public GameObject ComputerTaskUi;
    public GameObject UrinalTaskUi;
    public GameObject KitchenTaskUi;
    public GameObject MeetingTaskUi;
    public GameObject BossTaskUi;
    public GameObject ElevatorTaskUi;

    public Collider CloseTrigger;

    public GameObject NPC1;
    public GameObject NPC2;

    public Door kitchDoor;
    public Animator KitchenAnimator;
    public Animator MeetingAnimator;

    public Door PeeDoor;
    public Animator PeeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ComputerTaskUi.SetActive(true);
        jukebox = JukeBoxObj.GetComponent<Jukebox>();
        //kitchDoor.enabled = false;
        KitchenAnimator.enabled = false;
       // PeeDoor.enabled = false;
        PeeAnimator.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        //ENABLED URINALS

        //PeeDoor.canOpen = PeeAnimator.enabled;
       // kitchDoor.canOpen = KitchenAnimator.enabled;



    }

    public bool Interact(Interactor interactor)
    {
        if (Days != 5)
        {
            ToDoList.SetActive(false);
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
            BossCooldown = false;
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
            CloseTrigger.enabled = true;
            
            if (Days == 2)
            {
                PeeDoor.canOpen = true;
                computer.score = 0;
                BossCheck = false;
                computer.resetGame();
                computerIsWin = false;
                ComputerIsDone = false;
                computer.score = 0;
                
                urinalIsWin = false;
                UrinalIsDone = false;
                BossCooldown = false;
                ToDoList.SetActive(true);
                ElevatorTaskUi.SetActive(false);
                BossTaskUi.SetActive(false);
                ComputerTaskUi.SetActive(true);
                UrinalTaskUi.SetActive(true);
                CloseTrigger.enabled = true;
               
            }
            if(Days == 3)
            {
                kitchDoor.enabled = true;
                KitchenAnimator.enabled = true;
                computer.score = 0;
                BossCheck = false;
                computer.resetGame();
                urinalIsWin = false;
                UrinalIsDone = false;
                computerIsWin = false;
                ComputerIsDone = false;
                kitchenIsWin = false;
                KitchenIsDone = false;
                kitchenObjs.ResetObjs();
                BossCooldown = false;
                ToDoList.SetActive(true);
                KitchenTaskUi.SetActive(true);
                CloseTrigger.enabled = true;
            }
            if(Days == 4)
            {
                MeetingAnimator.enabled = true;
                computer.score = 0;
                BossCheck = false;
                computer.resetGame();
                computerIsWin = false;
                ComputerIsDone = false;
                meetingIsWin = false;
                MeetingIsDone = false;
                kitchenIsWin = false;
                KitchenIsDone = false;
                kitchenObjs.ResetObjs();
                urinalIsWin = false;
                UrinalIsDone = false;
                BossCooldown = false;
                ToDoList.SetActive(true);
                MeetingTaskUi.SetActive(true);
                CloseTrigger.enabled = true;
            }
            if (Days == 5)
            {
                BossCheck = false;
                computer.resetGame();
                ToDoList.SetActive(true);
                AbleToChase = true;
                jukebox.StopMus();
                jukebox.startMus = false;
                ComputerIsDone = true;
                MeetingIsDone = true;
                KitchenIsDone = true;
                kitchenObjs.ResetObjs();
                UrinalIsDone = true;
                CloseTrigger.enabled = true;
                NPC1.SetActive(false);
                NPC2.SetActive(false);


            }

        }
        
    }
}
