using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour, Iinteractable
{
    public GameObject Kitchen;
    KitchenGame kitchenGame;
    public AudioSource audioSource;

    public AudioClip Grind;
    public AudioClip Beans;
    public AudioClip Pour;

    public GameObject Drink;

    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject kitchenObjects;
    KitchenObjs kitchenObjs;
    // Start is called before the first frame update
    void Start()
    {
        kitchenGame = Kitchen.GetComponent<KitchenGame>();
        kitchenObjs = kitchenObjects.GetComponent<KitchenObjs>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coffee" && kitchenGame.coffeeStage == 0)
        {
            audioSource.PlayOneShot(Beans);
            kitchenGame.coffeeStage = 1;
            Debug.Log(kitchenGame.coffeeStage);

        }

        if (other.gameObject.tag == "Mug" && kitchenGame.coffeeStage == 2)
        {
            kitchenGame.coffeeStage = 3;
            audioSource.PlayOneShot(Pour);
            Debug.Log(kitchenGame.coffeeStage);
            Drink.SetActive(true);
            kitchenObjs.coffeeDrink = false;
            Debug.Log("done");
            

        }



    }

    public bool Interact(Interactor interactor)
    {
        if(kitchenGame.coffeeStage == 1)
        {
            kitchenGame.coffeeStage = 2;
            audioSource.PlayOneShot(Grind);
            Debug.Log(kitchenGame.coffeeStage);

        }
        return true;
    }



}
