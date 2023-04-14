using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    

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

    int score;
    int index;
    int index2;

    public GameObject[] Spots;
    public GameObject CurrentSpot;

    public AudioSource audioSource;
    public AudioClip type;

    public bool cooldown;
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
        playerMovement = Player.GetComponent<PlayerMovement>();
        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();
        gameManager = manager.GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 10)
        {
            playerMovement.InGame = false;
            gameManager.gameActive = false;
            firstPersonCameraRotation.FreezeMovement = false;
            hand.SetActive(false);
            Player.transform.position = new Vector3(135, 7.4f, 93.8f);
            Debug.Log("you are win");
        }
    }

    IEnumerator StartComputing()
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

    void LookAt()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        Camera.transform.LookAt(target.transform.position, Vector3.up);
    }
    // code outline

    //Enable the hand object that was present THE WHOLE TIME. IT WAS ME BARRY.


    public void CallSpot()
    {
        index = Random.Range(0, Spots.Length);
        CurrentSpot = Spots[index];
        CurrentSpot.SetActive(true);
        cooldown = false;
    }


    IEnumerator Reset()
    {

        audioSource.PlayOneShot(type, 1.0f);
        yield return new WaitForSeconds(1.0f);
        CallSpot();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && cooldown == false)
        {
            cooldown = true;
            Debug.Log("tipe");
            score = score + 1;
            CurrentSpot.SetActive(false);
            StartCoroutine(Reset());

        }


    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        playerMovement.InGame = false;
        gameManager.gameActive = false;
        firstPersonCameraRotation.FreezeMovement = false;
        hand.SetActive(false);
        Debug.Log("you are win");
    }
}
