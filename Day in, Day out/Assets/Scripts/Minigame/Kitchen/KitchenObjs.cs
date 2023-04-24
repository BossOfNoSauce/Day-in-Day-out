using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjs : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public Rigidbody RB;
    public Transform ObjectGrabPointTransform;


    public bool GrabBool;

    public GameObject Kitchen;
     KitchenGame kitchenGame;

    public AudioSource audioSource;
    public AudioClip Drink;

    public GameObject cMachine;
    CoffeeMachine coffeeMachine;

    public bool coffeeDrink;
    // Start is called before the first frame update
    void Start()
    {
        kitchenGame = Kitchen.GetComponent<KitchenGame>();
        coffeeMachine = cMachine.GetComponent<CoffeeMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
       
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;

            GrabBool = !GrabBool;
        RB.freezeRotation = !RB.freezeRotation;
        RB.useGravity = !RB.useGravity;
        //Set bool to enable the cup moving toward the orgin point
        // man we use a lkot of bools




        return true;
    }

    public void FixedUpdate()
    {
        if (GrabBool == true)
        {
            if (ObjectGrabPointTransform != null)
            {
                RB.MovePosition(ObjectGrabPointTransform.position);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (kitchenGame.coffeeStage == 3 && GrabBool && coffeeDrink == false)
            {
                audioSource.PlayOneShot(Drink);
                coffeeMachine.Drink.SetActive(false);
                kitchenGame.CoffeeIsDone = true;
                coffeeDrink = true;
            }
            
        }

     

    }
}
