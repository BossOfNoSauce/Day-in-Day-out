using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;

    PlayerRaycast playerRaycast;
    HAND Hand;

    public int coffeeStage = 0;
    public int noodleStage = 0;
    public bool CoffeeIsDone;
    public bool NoodlesIsDone;
    //i know improper grammer, stfu

    // Start is called before the first frame update
    void Start()
    {
        playerRaycast = Player.GetComponent<PlayerRaycast>();
        Hand = Arm.GetComponent<HAND>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerRaycast.CanInteract = true;
            Arm.SetActive(true);
            Hand.HandActive = false;
            //Arm.transform.position = new Vector3(1f, 1f, 1f);

        }
    }
}
