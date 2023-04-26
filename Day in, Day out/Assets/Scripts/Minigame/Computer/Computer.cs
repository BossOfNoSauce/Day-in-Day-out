using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    //found bugs
    //  []can open pause menu while playing
    //  []game doesnt end
    //  []no fail state in script
    //      [x]add bad buttons no press
    //      []make new array for bad button & rename spots to good btn
    //      []recode button logic
    //          []

    public GameObject manager;
    GameManager gameManager;

    
    public GameObject target;
    public GameObject Camera;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject hand;

    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public Collider Mcollider;

    public  int score;
    int index;
    int index2;

    public GameObject[] Spots;
    public GameObject CurrentSpot;

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
            playerMovement.InGame = true;
            gameManager.gameActive = true;
            // Mcollider.enabled = !Mcollider.enabled;
            yield return new WaitForSeconds(3);
            CallSpot();
            Player.transform.position = new Vector3(138, 5.5f, 93.8f);
            firstPersonCameraRotation.FreezeMovement = true;
            hand.SetActive(true);
            LookAt();
        }
        
        
    }

    void LookAt()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        Camera.transform.LookAt(target.transform.position, Vector3.up);
    }
    // code outline

    //Enable the hand object that was present THE WHOLE TIME. IT WAS ME BARRY.


    public void CallSpot()
    {
        if(score < 10)
        {
            index = Random.Range(0, Spots.Length);
            CurrentSpot = Spots[index];
            CurrentSpot.SetActive(true);
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
            Mcollider.enabled = false;
            //WHY NO WORK
            playerMovement.InGame = false; //is good
            gameManager.gameActive = false; //is good
            firstPersonCameraRotation.FreezeMovement = false; // si good
            hand.SetActive(false);
            Player.transform.position = new Vector3(136, 8.5f, 93.8f);
            cooldown2 = true;
            daySystem.ComputerIsDone = true;
            //Fix... call function once
        }

    }

    public void DummyFunc()
    {
        cooldown = true;
        
        score = score + 1;
        CurrentSpot.SetActive(false);
        StartCoroutine(Reset());
    }

   
}
