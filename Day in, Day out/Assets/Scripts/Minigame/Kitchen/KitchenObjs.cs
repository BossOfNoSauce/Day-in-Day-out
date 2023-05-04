using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjs : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public Rigidbody RB;
    public Transform ObjectGrabPointTransform;

    public GameObject Noodles;
    public GameObject Mug;
    public GameObject Bag;

    public bool GrabBool;

    public GameObject Kitchen;
     KitchenGame kitchenGame;

    public AudioSource audioSource;
    public AudioClip Drink;

    public GameObject cMachine;
    CoffeeMachine coffeeMachine;
    //has consumed yet?
    public bool coffeeDrink;
    public bool noodleEat = false;

    public bool AbleToGrab = true;
    // Start is called before the first frame update
    void Start()
    {
        AbleToGrab = true;
        kitchenGame = Kitchen.GetComponent<KitchenGame>();
        coffeeMachine = cMachine.GetComponent<CoffeeMachine>();
    }

    public void ResetObjs()
    {
        kitchenGame.coffeeStage = 0;
        kitchenGame.noodleStage = 0;
        Noodles.transform.position = new Vector3(35, 4.5f, -68);
        Mug.transform.position = new Vector3(34, 1.5f, -61);
        Bag.transform.position = new Vector3(34, 1, -66);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        if (kitchenGame.coffeeStage == 3 && GrabBool && coffeeDrink == false)//coffee stage only goes to 3 when mug in hand, so this is fine
        {//drink coffee when in hand
            Debug.Log("drinkiung coffee");
            audioSource.PlayOneShot(Drink);
            coffeeMachine.Drink.SetActive(false);
            kitchenGame.CoffeeIsDone = true;
            coffeeDrink = true;
        }
        else if (kitchenGame.noodleStage == 2 && GrabBool && noodleEat == false)//coffee stage only goes to 3 when mug in hand, so this is fine
        {//drink coffee when in hand
            Debug.Log("eating noodles");
            audioSource.PlayOneShot(Drink);
            kitchenGame.NoodlesIsDone = true;
            noodleEat = true;
        }
        else
        {
            Debug.Log("dropping / grabbing item");
            this.ObjectGrabPointTransform = ObjectGrabPointTransform;

            GrabBool = !GrabBool;
            RB.freezeRotation = !RB.freezeRotation;
            RB.useGravity = !RB.useGravity;
            //Set bool to enable the cup moving toward the orgin point
            // man we use a lkot of bools
        }



        return true;
    }
    public void simDrop()
    {
        Debug.Log("simulating dropping / grabbing item");
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;

        GrabBool = !GrabBool;
        RB.freezeRotation = !RB.freezeRotation;
        RB.useGravity = !RB.useGravity;
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
            
            
        }

     if (AbleToGrab == true)
     {
            gameObject.layer = LayerMask.NameToLayer("Interact");
            
     }
     if (AbleToGrab == false)
     {

            gameObject.layer = default;
     }
    }
}
