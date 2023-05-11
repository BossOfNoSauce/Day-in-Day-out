using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;
    //rewrite-outline
    //[]find the color setter
    //[]add two public gameobjects for the check and cross
    //  []reveal proper check / cross by replacing the color thing
    //[]delet unecissary vars
    public bool cooldown;
   
    HAND Hand;

    public int coffeeStage = 0;
    public int noodleStage = 0;
    public bool CoffeeIsDone;
    public bool NoodlesIsDone;

    public AudioSource audioSource;
    public AudioClip ticking;
    public AudioClip urgency;

    public GameObject timer;
    //i know improper grammer, stfu

    public GameObject DayManager;
    DaySystem daySystem;
    bool runOnce = true;

    public Microwave microwave;
    //todo ui stuff
    public GameObject kitchenCheck;
    public GameObject kitchenCross;
    void Start()
    {
        daySystem = DayManager.GetComponent<DaySystem>();
        Hand = Arm.GetComponent<HAND>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CoffeeIsDone == true && NoodlesIsDone == true && runOnce)
        {
            runOnce = false;
            timer.SetActive(false);
            Arm.SetActive(false);
            Hand.HandActive = true;
            daySystem.kitchenIsWin = true;
            daySystem.KitchenIsDone = true;
            StopCoroutine(GameTimer());
            kitchenCheck.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(cooldown == false)
            {
                Arm.SetActive(true);
                StartCoroutine(GameTimer());
                cooldown = true;
            }
            

       

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Arm.SetActive(false);
            Hand.HandActive = true;
            
            

            if(daySystem.kitchenIsWin || daySystem.KitchenIsDone)
            {
                StopCoroutine(GameTimer());
            }
        }
    }

    IEnumerator GameTimer()
    {
        timer.SetActive(true);
        audioSource.PlayOneShot(ticking);
        Arm.transform.localPosition = new Vector3(0.004f, 0.523f, 1.44f);
        Hand.HandActive = false;
        //game timer enabled
        yield return new WaitForSeconds(45);
        audioSource.PlayOneShot(urgency);
        yield return new WaitForSeconds(45);
        if(CoffeeIsDone == false && NoodlesIsDone == false)
        {
            daySystem.KitchenIsDone = true;
            daySystem.kitchenIsWin = false;
            timer.SetActive(false);
            Debug.Log("you fucked up");
            kitchenCross.SetActive(true);
        }
    }

    public void ResetObState()
    {
        kitchenCheck.SetActive(false);
        kitchenCross.SetActive(false);
        NoodlesIsDone = false;
        CoffeeIsDone = false;
        noodleStage = 0;
        coffeeStage = 0;
        microwave.thebool = true;
    }
}
