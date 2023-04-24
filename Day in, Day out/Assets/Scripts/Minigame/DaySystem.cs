using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
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
        if (Days == 1 )
        {
            StartCoroutine(EndDay());
        }

        if (Days == 2 )
        {
            StartCoroutine(EndDay());
        }
    }

    IEnumerator EndDay()
    {
        //play day end sound
        yield return new WaitForSeconds(3);
        Days++;
    }
}
