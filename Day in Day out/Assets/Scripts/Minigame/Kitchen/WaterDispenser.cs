using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDispenser : MonoBehaviour
{
    public GameObject Kitchen;
    KitchenGame kitchenGame;
   public AudioSource audioSource;

    public AudioClip water;
    // Start is called before the first frame update
    void Start()
    {
        kitchenGame = Kitchen.GetComponent<KitchenGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Noodles")
        {
            kitchenGame.noodleStage = 1;
            audioSource.PlayOneShot(water, 0.7f);
            Debug.Log(kitchenGame.noodleStage);
        }
    }
}
