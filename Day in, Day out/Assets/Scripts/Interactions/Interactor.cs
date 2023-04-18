using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [SerializeField] public Transform interactionPoint;
    [SerializeField] public float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    public InteractionPromptUI interactionPromptUI;
    

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private Iinteractable interactable;

    public Transform objectGrabPointTransform;

    public bool NoInteract; 

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (NoInteract == false)
        {

            if (numFound > 0)
            {
                interactable = colliders[0].GetComponent<Iinteractable>();

                if (interactable != null)
                {
                    /* if (!interactionPromptUI.IsDisplayed)
                     {
                         interactionPromptUI.SetUp(interactable.InteractionPrompt);
                     } */

                    if (Input.GetKeyDown("e"))
                    {
                        interactable.Interact(this);
                    }
                }


            }
            else
            {
                if (interactable != null)
                {
                    interactable = null;
                }

                /* if (interactionPromptUI.IsDisplayed)
                 {
                     interactionPromptUI.Close();
                 }*/
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
