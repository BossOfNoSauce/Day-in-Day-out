using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    //found bugs, bugs are squished now
    //  [X]can open pause menu while playing
    //  [x]game doesnt end
    //  [X]no fail state in script
    //      [x]add bad buttons no press
    //      [x]make new array for bad button & rename spots to good btn
    //      [x]add ui elements
    //          [x]tutorial screen
    //          [x]in game ui
    //              [x]score display
    //              [x]life counter
    //      [x]recode button logic
    //          [x]if hand collide with bad key, game end || a counter (like a hp bar) goes down and 0 == fail
    //rewrite-outline
    //[x]find where daysystem script is called
    //  [-]add if not found
    //[x]call corrisponding bools wihtin the daySystem script
    //  [x]make dayWin/Fail into one bool
    //[]get ToDo script
    //  []change corrisponding bools
    public GameObject manager;
    GameManager gameManager;
    public ToDo toDoScript;



    
    public GameObject target;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject hand;

    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public int score;
    //spots
    public GameObject[] goodSpots;
    public GameObject[] badSpots;
    GameObject goodCurrentSpot;
    GameObject badCurrentSpot;
    //--===UI===--//
    public GameObject tutUi;
    public GameObject gameUi;
    public GameObject scoreText;
    TextMeshProUGUI text;
    public GameObject pauseMenu;
    PauseGame pause;
    public Image[] lifeCountUi;//should never be greater than 3
    int life = 3;
    public GameObject computerCheck;//for todo list
    //audio
    public AudioSource audioSource;
    public AudioClip type;
    //timeing
    public bool cooldown;
    public bool cooldown2;
    //game win states
    bool isGameWin;
    bool isGameFinished = false;
    //so that you cant use computer while cutscene plays
    public bool canCompute = false;

    public GameObject DayManager;
    DaySystem daySystem;
    public bool Interact(Interactor interactor)
    {
        Debug.Log(canCompute);
        Debug.Log(isGameFinished);
        //this is what happenes when you interact

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

        if(daySystem.ComputerIsDone == false)
        {
            canCompute = true;
        }

       
    }

    public IEnumerator StartComputing()
    {
        if (canCompute == true)
        {

            if (daySystem.ComputerIsDone == false)
            {
                life = 3;
                pause.AbleToPause = false;
                playerMovement.InGame = true;
                gameManager.gameActive = true;
                Player.transform.position = new Vector3(138, 5.5f, 93.8f);
                firstPersonCameraRotation.FreezeMovement = true;

                pause.simPaused();
                tutUi.SetActive(true);

                LookAt();
                yield return new WaitForSeconds(1);
                hand.SetActive(true);
                CallSpot();
            }
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

    

    IEnumerator EndGame()//add a fail think here
    {
        if(cooldown2 == false)
        {
            yield return new WaitForSeconds(1);
            playerMovement.InGame = false; 
            gameManager.gameActive = false; 
            firstPersonCameraRotation.FreezeMovement = false; 
            hand.SetActive(false);
            gameUi.SetActive(false);
            pause.AbleToPause = true;
            Player.transform.position = new Vector3(136, 7.41f, 93.8f);
            cooldown2 = true;
            if(score >= 10)
            {
                isGameWin = true;
            }
            else
            {
                isGameWin = false;
            }
            isGameFinished = true;
            daySystem.ComputerIsDone = true;
            daySystem.computerIsWin = isGameWin;
            //set check list, rewrite when todo sprites come in
            Image temp = computerCheck.GetComponent<Image>();
            temp.color = (isGameWin ?  new Color32(0, 255, 0, 100) : new Color32(255, 0, 0, 100));//if game is win, set image to green, else red
        }

    }

    public void keyCollide(bool isGood)
    {
        cooldown = true;
        if (isGood)
        {
            score = score + 1;
        }
        else
        {
            life--;
            lifeCountUi[life].color = new Color32(255, 0, 0, 100);
            

            //lifeDisplay[life-1].gameObject.c//change color to red here
            if (life <= 0)
            {
                StartCoroutine(EndGame());
            }
        }
        text.text = "score = " + score + " / 10";
        goodCurrentSpot.SetActive(false);
        badCurrentSpot.SetActive(false);
        StartCoroutine(Reset());
    }

    

   
}
