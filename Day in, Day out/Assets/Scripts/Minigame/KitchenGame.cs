using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hand.SetActive(true);

        }
    }
}
