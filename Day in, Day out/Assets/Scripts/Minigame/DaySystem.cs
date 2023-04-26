using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;

    public bool cooldown;

    public bool ComputerIsDone;
    public bool KitchenIsDone;
    public bool UrinalIsDone;
    public bool MeetingIsDone;
    public int Days = 1;

    public bool BossCheck;
    // what we will do is have the boss check per day in his own script and look if bool is done, then it will enable a boss check bool which will allow sday transition;
    // Start is called before the first frame update
    void Start()
    {
        //i apologize to all who read this terrible code, its horribly inefficent, but it works. im sorry
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Days == 2 )
        {
            //StartCoroutine(EndDay());
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (Days == 1)
        {
            if (BossCheck == true)
            {
                StartCoroutine(EndDay());
            }

        }

        return true;
    }


    IEnumerator EndDay()
    {
        if(cooldown == false)
        {
            //play day end sound
            Debug.Log("day end");
            yield return new WaitForSeconds(3);
            Days++;
            cooldown = true;
        }
        
    }
}
