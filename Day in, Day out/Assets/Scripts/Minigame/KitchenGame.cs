using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Arm;

    HAND Hand;

    // Start is called before the first frame update
    void Start()
    {
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
            Arm.SetActive(true);
            Hand.HandActive = false;
            //Arm.transform.position = new Vector3(1f, 1f, 1f);

        }
    }
}
