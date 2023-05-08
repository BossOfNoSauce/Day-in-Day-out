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

    public AudioSource audioSource;
    public AudioClip ticking;
    public AudioClip urgency;

    public GameObject timer;
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
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(GameTimer());

       

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Arm.SetActive(false);
            Hand.HandActive = true;
            //Arm.transform.position = new Vector3(1f, 1f, 1f);
            if (CoffeeIsDone == true && NoodlesIsDone == true)
            {
                Arm.SetActive(false);
                Hand.HandActive = true;
                daySystem.kitchenIsWin = true;
                StopCoroutine(GameTimer());

            }
        }
    }

    IEnumerator GameTimer()
    {
        timer.SetActive(true);
        audioSource.PlayOneShot(ticking);
        Arm.SetActive(true);
        Arm.transform.localPosition = new Vector3(0.004f, 0.523f, 1.44f);
        Hand.HandActive = false;
        //game timer enabled
        yield return new WaitForSeconds(25);
        audioSource.PlayOneShot(urgency);
        yield return new WaitForSeconds(20);
        if(CoffeeIsDone == false && NoodlesIsDone == false)
        {
            daySystem.KitchenIsDone = true;
            timer.SetActive(false);
            //YOU FAIL

        }
    }
}
