using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;

   
    HAND Hand;

    public int coffeeStage = 0;
    public int noodleStage = 0;
    public bool CoffeeIsDone;
    public bool NoodlesIsDone;

    //i know improper grammer, stfu

    public GameObject DayManager;
    DaySystem daySystem;


    // Start is called before the first frame update
    void Start()
    {
        daySystem = DayManager.GetComponent<DaySystem>();
        Hand = Arm.GetComponent<HAND>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(CoffeeIsDone == true && NoodlesIsDone == true)
        {
            Arm.SetActive(false);
            Hand.HandActive = true;
            daySystem.MeetingIsDone = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Arm.SetActive(true);
            Hand.HandActive = false;
            //Arm.transform.position = new Vector3(1f, 1f, 1f);

        }
    }
}
