using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjs : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public Rigidbody RB;
    public Transform ObjectGrabPointTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        this.ObjectGrabPointTransform = ObjectGrabPointTransform;

        //Set bool to enable the cup moving toward the orgin point
        // man we use a lkot of bools
        return true;
    }

    public void FixedUpdate()
    {
        if(ObjectGrabPointTransform != null)
        {
            RB.MovePosition(ObjectGrabPointTransform.position);
        }


    }
}
