using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    //found bugs
    //  [X]can open pause menu while playing
    //  [x]game doesnt end
    //  [X]no fail state in script
    //      [x]add bad buttons no press
    //      [x]make new array for bad button & rename spots to good btn
    //      [/]add ui elements
    //          [x]tutorial screen
    //          [x]in game ui
    //              [/]score display
    //              []
    //      [x]recode button logic
    //          [/]if hand collide with bad key, game end || a counter (like a hp bar) goes down and 0 == fail

    public GameObject manager;
    GameManager gameManager;

    
    public GameObject target;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject hand;

    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public Collider Mcollider;

    public  int score;
    //spots
    public GameObject[] goodSpots;
    public GameObject[] badSpots;
    GameObject goodCurrentSpot;
    GameObject badCurrentSpot;
    //ui
    public GameObject tutUi;
    public GameObject gameUi;
    public GameObject scoreText;
    TextMeshProUGUI text;
    public GameObject pauseMenu;
    PauseGame pause;
    //audio
    public AudioSource audioSource;
    public AudioClip type;

    public bool cooldown;
    public bool cooldown2;

    public bool GameFail;
    public bool GameWin;

    public GameObject DayManager;
    DaySystem daySystem;
    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("Turning on computer");
        
        StartCoroutine(StartComputing());
        return true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        text = scoreText.GetComponent<TextMeshProUGUI>();
        pause = pauseMenu.GetComponent<PauseGame>();
        daySystem = DayManager.GetComponent<DaySystem>();
        playerMovement = Player.GetComponent<PlayerMovement>();
        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();
        gameManager = manager.GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= 10)
        {
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator StartComputing()
    {
        if(GameFail ==  false || GameWin == false)
        {
            pause.AbleToPause = false;
            playerMovement.InGame = true;
            gameManager.gameActive = true;
            Player.transform.position = new Vector3(138, 5.5f, 93.8f);
            firstPersonCameraRotation.FreezeMovement = true;
            
            pause.simPaused();
            tutUi.SetActive(true);

            //tutUi.SetActive(false);
            //pause.simResume();
            LookAt();
            yield return new WaitForSeconds(1);
            hand.SetActive(true);
            CallSpot();
        }
        
        
    }

    void LookAt()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        MainCam.transform.LookAt(target.transform.position, Vector3.up);
    }
    // code outline

    //Enable the hand object that was present THE WHOLE TIME. IT WAS ME BARRY.


    public void CallSpot()
    {
        if(score < 10)
        {
            //rand spot 0-3 for each
            int index = Random.Range(0, goodSpots.Length);
            int index2 = Random.Range(0, badSpots.Length);
            //Debug.Log("index 1 & 2, " + index + "/" + index2);//debug line
            //overlap correction code
            while(index == index2)
            {
                index2 = Random.Range(0, badSpots.Length);
            }
            //assighn spots and set active
            goodCurrentSpot = goodSpots[index];
            badCurrentSpot = badSpots[index2];
            goodCurrentSpot.SetActive(true);
            badCurrentSpot.SetActive(true);
            cooldown = false;           
        }
       
    }


    public IEnumerator Reset()
    {
        audioSource.PlayOneShot(type, 1.0f);
        yield return new WaitForSeconds(1.0f);
        CallSpot();
    }

    

    IEnumerator EndGame()
    {
        if(cooldown2 == false)
        {
            yield return new WaitForSeconds(1);
            playerMovement.InGame = false; //is good
            gameManager.gameActive = false; //is good
            firstPersonCameraRotation.FreezeMovement = false; // si good
            hand.SetActive(false);
            gameUi.SetActive(false);
            pause.AbleToPause = true;
            Player.transform.position = new Vector3(136, 8.5f, 93.8f);
            cooldown2 = true;
            daySystem.ComputerIsDone = true;
        }

    }

    public void keyCollide(bool isGood)
    {
        cooldown = true;
        if (isGood)
        {
            score = score + 1;
        }
        text.text = "score = " + score + " / 10";
        goodCurrentSpot.SetActive(false);
        badCurrentSpot.SetActive(false);
        StartCoroutine(Reset());
    }

   
}
