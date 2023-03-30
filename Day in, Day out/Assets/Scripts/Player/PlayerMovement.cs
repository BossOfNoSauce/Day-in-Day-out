using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;


    //public CharacterRotation = Transform.rotation;
    FirstPersonCameraRotation firstPersonCameraRotation;
    public GameObject MainCam;


    FirstPersonCameraRotation playerCam;
    public GameObject Camera;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded = true;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public AudioSource footstepsSound;

    public bool InGame = false;

    private void Awake()
    {
        playerCam = Camera.GetComponent<FirstPersonCameraRotation>();
    }

    private void Start()
    {
        firstPersonCameraRotation = MainCam.GetComponent<FirstPersonCameraRotation>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        
        transform.rotation = Camera.transform.rotation;
        //transform.rotation = Quaternion.identity;
        //transform.rotation = Quaternion.identity;


        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = groundDrag;

        }

        if (verticalInput > 0 || horizontalInput > 0)
        {
            footstepsSound.enabled = true;
            
        }
        else
        {
            footstepsSound.enabled = false;
        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        if(InGame == false)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
       


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }

    IEnumerator Pissing()
    {
        //game timer
        
        

        Debug.Log("takin a fat piss bro");
     
        yield return new WaitForSeconds(21);
        firstPersonCameraRotation.noMovement = false;
        InGame = false;
    }

    public void DummyFunc()
    {
        StartCoroutine(Pissing());
    }

}
