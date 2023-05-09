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
    public grabObj grab;

    public GameObject Kitchen;
     KitchenGame kitchenGame;
    public AudioSource audioSource;
    public AudioClip Drink;
    //mug coffee layer
    public GameObject cMachine;
    CoffeeMachine coffeeMachine;

    public bool AbleToGrab = true;

    public GameObject button;
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
        kitchenGame.CoffeeIsDone = false;
        kitchenGame.NoodlesIsDone = false;
        Noodles.transform.localPosition = new Vector3(35, 4.5f, -68);
        Mug.transform.localPosition = new Vector3(34, 1.5f, -61);
        Bag.transform.localPosition = new Vector3(34, 1, -66);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Interact(Interactor interactor)//i belive this needs to be moved into a single script
    {
        if (kitchenGame.coffeeStage == 3 && GrabBool && grab.coffeeDrink == false)//coffee stage only goes to 3 when mug in hand, so this is fine
        {//drink coffee when in hand
            Debug.Log("drinkiung coffee");
            audioSource.PlayOneShot(Drink);
            coffeeMachine.Drink.SetActive(false);
            kitchenGame.CoffeeIsDone = true;
            grab.coffeeDrink = true;
        }
        else if (kitchenGame.noodleStage == 2 && GrabBool && grab.noodleEat == false)//coffee stage only goes to 3 when mug in hand, so this is fine
        {//drink coffee when in hand
            Debug.Log("eating noodles");
            audioSource.PlayOneShot(Drink);
            kitchenGame.NoodlesIsDone = true;
            grab.noodleEat = true;
        }
        else
        {
            if (grab.grabbing && GrabBool || !grab.grabbing && ! GrabBool)//if this object is held or no objects are held
            {
                Debug.Log("dropping / grabbing item");
                this.ObjectGrabPointTransform = ObjectGrabPointTransform;

                button.SetActive(!button);

                grab.grabbing = !grab.grabbing;
                GrabBool = !GrabBool;//grab bool moves transform to grab point
                //sp trhat it dont fall / rotate away
                RB.freezeRotation = !RB.freezeRotation;
                RB.useGravity = !RB.useGravity;
            }
            else
            {
                Debug.Log("cant grab obj, hand full");
            }
        }



        return true;
    }
    public void simDrop()
    {
        Debug.Log("simulating dropping / grabbing item");
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;
        grab.grabbing = !grab.grabbing;
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
