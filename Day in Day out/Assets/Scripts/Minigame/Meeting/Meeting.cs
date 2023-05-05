using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Meeting : MonoBehaviour, Iinteractable 
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public DaySystem daySystem;

    public GameObject manager;
    GameManager gameManager;

    public Vector3 playerPosition;
    //player / cam stuff
    public GameObject Camera;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject MainCam;
    Collider collider;
    //eyelids
    public GameObject Top;
    public GameObject Bottom;
    //speed of the lids / power of forceing them open
    public float speed;
    public float Power;
    //eyelid rigidbodys
    Rigidbody TRB;
    Rigidbody BRB;
    RectTransform TRT;
    RectTransform BRT;
    //UI
    public GameObject meetingCheck;
    //game staTREW BOOLS
    public bool GameIsActive = false;
    bool isGameWin;
    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("Meeting Time");
        StartCoroutine(MeetingTime());
        return true;
    }

    public void Start()
    {
        //rigidbody stuff
        TRB = Top.GetComponent<Rigidbody>();
        BRB = Bottom.GetComponent<Rigidbody>();
        TRT = Top.GetComponent<RectTransform>();
        BRT = Bottom.GetComponent<RectTransform>();
        //player stuff
        playerMovement = Player.GetComponent<PlayerMovement>();
        gameManager = manager.GetComponent<GameManager>();
        collider = GetComponent<Collider>();
    }
    public void Update()
    {
        //topTarget = new Vector3(0, 0, 0);

        if (GameIsActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //TRB.transform.position.Set(0.0f, TRB.transform.position.y + 500.0f, 0.0f);//use if current one isnt that fun
                TRB.AddForce(Vector3.up * Power);
                BRB.AddForce(-Vector3.up * Power);
                
            }
            //checking just one lid bc they are mirrored objects
            if(TRT.anchoredPosition.y > 1200)
            {
                Sleepy();
            }
            //game end when lid closes pass 540, doing 500 for some leaway
            if(TRT.anchoredPosition.y < 500)
            {
                Debug.Log("failed meeting, ending game");
                isGameWin = false;
                endGame();
            }
        }
    }
    void endGame()//ends the game by resetting and setting bools
    {
        //set in game to false
        playerMovement.InGame = false;
        gameManager.gameActive = false;
        GameIsActive = false;
        daySystem.meetingIsWin = isGameWin;
        //reset player posiotion
        Player.transform.position = new Vector3(-15, 7.4f, -60.9f);
        collider.enabled = false;
        daySystem.MeetingIsDone = true;
        //RESET EYELIDS TO ORIGINAL POSIOTIONs and velocitys
        TRB.velocity = Vector3.zero;
        BRB.velocity = Vector3.zero;
        TRT.anchoredPosition = new Vector3(0.0f, 1200.0f, 0.0f);
        BRT.anchoredPosition = new Vector3(0.0f, -1200.0f, 0.0f);
        //set ui checklist / todo list
        Image temp = meetingCheck.GetComponent<Image>();
        temp.color = (isGameWin ? new Color32(0, 255, 0, 100) : new Color32(255, 0, 0, 100));//if game is win, set image to green, else red
    }
    void Sleepy()//reset eyelid speeds
    {
        //Makes the to black squares move over the camera
        TRB.velocity = new Vector3(0.0f, -speed, 0.0f);
        BRB.velocity = new Vector3(0.0f, speed, 0.0f);
    }
    public IEnumerator MeetingTime()//start game
    {
        {
            playerMovement.InGame = true;
            gameManager.gameActive = true;
            GameIsActive = true;
            collider.enabled = false;
            yield return new WaitForSeconds(3);
            Player.transform.position = new Vector3(-19, 6.5f, -65);
            yield return new WaitForSeconds(3.25f);
            Sleepy();
            yield return new WaitForSeconds(20f);
            if (GameIsActive)
            {//just in case somehow game ends and this is still running
                Debug.Log("meeting win, ending game");
                isGameWin = true;
                endGame();
            }
        }
    }
}
