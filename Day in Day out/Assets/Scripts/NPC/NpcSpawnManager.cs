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
    public GameObject ToiletGuy;
    // Start is called before the first frame update
    void Start()
    {
        Doughnut.SetActive(true);
        FileGuy.SetActive(true);
        ClockGuy.SetActive(true);
        PhoneLady.SetActive(true);
        Smoker.SetActive(true);
        ToiletGuy.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(ds.Days == 1)
        {
            
        }
        if (ds.Days == 2)
        {
            Doughnut.SetActive(false);
            
        }
        if (ds.Days == 3)
        {

            Smoker.SetActive(false);
            ToiletGuy.SetActive(false);
        }
        if (ds.Days == 4)
        {
            FileGuy.SetActive(false);
            ClockGuy.SetActive(false);
        }
        if (ds.Days == 5)
        {
            
            PhoneLady.SetActive(false);
           
        }
    }
}
