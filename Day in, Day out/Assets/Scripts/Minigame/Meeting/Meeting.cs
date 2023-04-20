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
    public Transform topTarget;
    public Transform bottomTarget;

    public Rigidbody TRB;
    public Rigidbody BRB;
    
    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("Meeting Time");
        StartCoroutine(MeetingTime());
        return true;
    }

    void Sleepy()
    {
        float step = speed * Time.deltaTime;
        TRB.MovePosition(topTarget.position);
        BRB.MovePosition(bottomTarget.position);

       //Top.transform.position = Vector3.MoveTowards(Top.transform.position, topTarget.position, step);
       // Bottom.transform.position = Vector3.MoveTowards(Bottom.transform.position, bottomTarget.position, step);
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
