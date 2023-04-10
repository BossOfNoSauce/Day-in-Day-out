using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;


    public GameObject GameManager;
    GameManager gameManager;

    public GameObject target;
    public GameObject Camera;
    PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject hand;

    public GameObject MainCam;
    FirstPersonCameraRotation firstPersonCameraRotation;

    public Collider Mcollider;

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
        gameManager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartComputing()
    {
        gameManager.gameActive = true;
        Mcollider.enabled = !Mcollider.enabled;
        yield return new WaitForSeconds(3);
        Player.transform.position = new Vector3(138, 5.5f, 93.8f);
        playerMovement.InGame = true;
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
    //this does work, but it still might be better to freeze camera movement, and instead use mouse to control only the hand. as the current way has fucky rotation.
    //but thats sound hard to do.

    // collision array, like the parking game
    // uh idk after that
}
