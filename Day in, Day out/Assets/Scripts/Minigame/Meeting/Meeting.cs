using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meeting : MonoBehaviour, Iinteractable 
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject manager;
    GameManager gameManager;

    public Vector3 playerPosition;

    public GameObject Camera;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject MainCam;
    Collider collider;

    public GameObject Top;
    public GameObject Bottom;

    public float speed;
    public float Power = 13000f;
    public Transform topTarget;
    public Transform bottomTarget;

    public Rigidbody TRB;
    public Rigidbody BRB;

    public bool GameIsActive = false;
    
    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("Meeting Time");
        StartCoroutine(MeetingTime());
        return true;
    }


    public void FixedUpdate()
    {
        //topTarget = new Vector3(0, 0, 0);

        if (GameIsActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TRB.AddForce(Vector3.up * Power);
                BRB.AddForce(-Vector3.up * Power);
                Sleepy();
            }
        }

    }

    void Sleepy()
    {
        //Makes the to black squares move over the camera
        Vector3 topDirection = topTarget.transform.position - TRB.transform.position;
        Vector3 bottomDirection = bottomTarget.transform.position - BRB.transform.position;
      
        Vector3 topVector = topDirection.normalized * speed;
        Vector3 bottomVector = bottomDirection.normalized * speed;
        TRB.velocity = topVector;
        BRB.velocity = bottomVector;

        GameIsActive = true;

        
    }

    void Awake()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        gameManager = manager.GetComponent<GameManager>();
        collider = GetComponent<Collider>();
    }
   
    public IEnumerator MeetingTime()
    {
        {
            playerMovement.InGame = true;
            gameManager.gameActive = true;
            collider.enabled = false;
            yield return new WaitForSeconds(3);
            Player.transform.position = new Vector3(-19, 6.5f, -65);
            yield return new WaitForSeconds(3.25f);
            Sleepy();
        }


    }
}
