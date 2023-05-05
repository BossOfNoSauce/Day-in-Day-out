using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject Comput;

    Computer computer;
    public bool isGood = true;
    // Start is called before the first frame update
    void Start()
    {
        computer = Comput.GetComponent<Computer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && computer.cooldown == false)
        {
            computer.keyCollide(isGood);

        }
    }
}
