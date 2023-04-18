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

    public bool Interact(Interactor interactor)
    {
        //this is what happenes when you interact
        Debug.Log("Meeting Time");
        StartCoroutine(MeetingTime());
        return true;
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
            Player.transform.position = new Vector3(-18, 5.5f, -54);
        }


    }
}
