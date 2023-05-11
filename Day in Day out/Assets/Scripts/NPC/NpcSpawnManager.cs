using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnManager : MonoBehaviour
{
    public DaySystem ds;
    public GameObject PhoneLady;
    public GameObject ClockGuy;
    public GameObject Smoker;
    public GameObject Doughnut;
    public GameObject FileGuy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ds.Days == 1)
        {
            Doughnut.SetActive(true);
            FileGuy.SetActive(true);
        }
        if (ds.Days == 2)
        {
            Doughnut.SetActive(false);
            ClockGuy.SetActive(true);
        }
        if (ds.Days == 3)
        {
            PhoneLady.SetActive(true);
            Smoker.SetActive(true);
            
        }
        if (ds.Days == 4)
        {
            FileGuy.SetActive(false);
            ClockGuy.SetActive(false);
        }
        if (ds.Days == 5)
        {
            Smoker.SetActive(false);
            PhoneLady.SetActive(false);
           
        }
    }
}
