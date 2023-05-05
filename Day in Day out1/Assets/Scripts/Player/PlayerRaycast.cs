using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject player;
    Interactor interactor;

    public bool CanInteract;


    public Transform playerCameraTransform;
    public LayerMask pickUpLayerMask;


    private void Start()
    {
        interactor = player.GetComponent<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanInteract == true)
        {
            interactor.NoInteract = true;
        }



        if (Input.GetKeyDown(KeyCode.E) || CanInteract == true)
        {
            float pickUpDistance = 2f;
            if ( Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if(raycastHit.transform.TryGetComponent(out KitchenObjs kitchenObjs)){
                    Debug.Log(kitchenObjs);
                }
               
            }
        }
    }
}
