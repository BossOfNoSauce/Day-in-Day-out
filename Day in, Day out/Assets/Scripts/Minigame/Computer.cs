using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

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
    void Start()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartComputing()
    {
        Mcollider.enabled = !Mcollider.enabled;
        yield return new WaitForSeconds(3);
        Player.transform.position = new Vector3(140, 5.5f, 93.8f);
        playerMovement.InGame = true;
        hand.SetActive(true);
        
    }

    // code outline
  
    //Enable the hand object that was present THE WHOLE TIME. IT WAS ME BARRY.
    //this does work, but it still might be better to freeze camera movement, and instead use mouse to control only the hand. as the current way has fucky rotation.
    //but thats sound hard to do.

    // collision array, like the parking game
    // uh idk after that
}
