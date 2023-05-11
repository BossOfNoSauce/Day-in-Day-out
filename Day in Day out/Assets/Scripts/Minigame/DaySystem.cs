using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaySystem : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;
    //player stuff
    public PlayerMovement playerMovement;
    public GameObject player;

    public PauseGame pause;
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
    //boss stuff
    public bool BossCheck;
    public bool AbleToChase;
    public bool BossCooldown;
    public GameObject JukeBoxObj;
    Jukebox jukebox;
    //animations
    public GameObject BlackScreen;
    public Animator animator;//screen fade
    public Animator elevator;
    //game scripts, for reseting purpuses
    public Computer computer;
    public KitchenObjs kitchenObjs;
    //todo list
    public GameObject ToDoList;
    //todo list ui elements
    public GameObject ComputerTaskUi;
    public GameObject UrinalTaskUi;
    public GameObject KitchenTaskUi;
    public GameObject MeetingTaskUi;
    public GameObject BossTaskUi;
    public GameObject ElevatorTaskUi;
    //fail screen ui
    public GameObject failScreen;

    public Collider CloseTrigger;

    public GameObject NPC1;
    public GameObject NPC2;

    public Door kitchDoor;
    public Animator KitchenAnimator;

    public Door meetingDoor;
    public Animator MeetingAnimator;

    public Door PeeDoor;
    public Animator PeeAnimator;

    public AudioClip B;

    public KitchenGame kitchenGame;

    public GameObject Tint;
   Image image;

    

    public bool temp = false;
    // Start is called before the first frame update
    void Start()
    {
        ComputerTaskUi.SetActive(true);
        jukebox = JukeBoxObj.GetComponent<Jukebox>();
        //kitchDoor.enabled = false;
        KitchenAnimator.enabled = false;
       // PeeDoor.enabled = false;
        PeeAnimator.enabled = false;
        MeetingAnimator.enabled = false;
        image = gameObject.GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        if (temp)
        {
            resetDay();
            temp = false;
        }

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
            animator.SetTrigger("Ftb");//fade out
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(DaySound); 
            yield return new WaitForSeconds(13);
            
            Days++;
            animator.SetTrigger("fob");//fade in
            yield return new WaitForSeconds(2);
            elevator.SetTrigger("Elevator Open");
            audioSource.PlayOneShot(OpeningElevator);
            cooldown = true;
            jukebox.startMus = true;
            ComputerIsDone = false;
            playerMovement.InGame = false;
            CloseTrigger.enabled = true;
            ToDoList.SetActive(true);
            ComputerTaskUi.SetActive(true);
            UrinalTaskUi.SetActive(true);
            ElevatorTaskUi.SetActive(false);
            BossTaskUi.SetActive(false);
            if (Days == 2)
            {
                PeeDoor.canOpen = true;
                PeeAnimator.enabled = true;
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
                kitchenGame.ResetObState();
                kitchenGame.cooldown = false;
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
                ElevatorTaskUi.SetActive(false);
                BossTaskUi.SetActive(false);
            }
            if(Days == 4)
            {
                kitchenGame.ResetObState();
                kitchenGame.cooldown = false;
                meetingDoor.canOpen = true;
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
                ElevatorTaskUi.SetActive(false);
                BossTaskUi.SetActive(false);
            }
            if (Days == 5)
            {
                Tint.GetComponent<Image>().color = new Color32(255, 0, 15, 26);
                audioSource.Play();
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
                
                ElevatorTaskUi.SetActive(false);
                BossTaskUi.SetActive(false);


            }

        }
        
    }
    public void resetDay()
    {
        Debug.Log("reseting day");
        StartCoroutine(reset());
    }
    IEnumerator reset()
    {
        Debug.Log("fade out");
        //fade out and reveal text "YOUR FIRED" w/ a reset button
        animator.SetTrigger("Ftb");//fade out
        yield return new WaitForSeconds(2);
        Debug.Log("showing fail screen & simPause");
        pause.AbleToPause = false;
        pause.simPaused();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        failScreen.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        BossCooldown = false;
        //set player to inside elevator
        Debug.Log("putting player into elevator");
        player.transform.position = new Vector3(142, 7.4f, -43f);
        playerMovement.InGame = true;
        Debug.Log("fade in");
        animator.SetTrigger("fob");//fade in
        yield return new WaitForSeconds(2);
        elevator.SetTrigger("Elevator Open");
        audioSource.PlayOneShot(OpeningElevator);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        cooldown = true;
        jukebox.startMus = true;
        playerMovement.InGame = false;
        CloseTrigger.enabled = true;
        //reset games
        BossCooldown = false;
        BossCheck = false;
        //reset computer
        computer.score = 0;
        computer.resetGame();
        //reset kitchen
        kitchenGame.ResetObState();
        kitchenObjs.ResetObjs();
        kitchenGame.cooldown = false;
        //urinal and meeting dont need a reset
        //reset all game bools
        computerIsWin = false;
        ComputerIsDone = false;
        urinalIsWin = false;
        UrinalIsDone = false;
        MeetingIsDone = false;
        kitchenIsWin = false;
        KitchenIsDone = false;
        meetingIsWin = false;
        MeetingIsDone = false;
        //show todo lsit
        ToDoList.SetActive(true);
        ComputerTaskUi.SetActive(true);
        if(Days > 1)
        {
            UrinalTaskUi.SetActive(true);
        }
        if(Days > 2)
        {
            KitchenTaskUi.SetActive(true);
        }
        if(Days > 3)
        {
            MeetingTaskUi.SetActive(true);
        }
        CloseTrigger.enabled = true;
    }
}
