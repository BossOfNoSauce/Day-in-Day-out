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

    public AudioSource audioSource;

    public bool InGame = false; //sets the minigames to freeze movement. doesnt fuckin work


    public float stamina = 100f;

    
    public float runSpeed = 10f;
    public float walkSpeed = 5f;

    public float drainRate = 1f;
    public float reChargeRate = 1f;

    public float fatigueTimer = 0f;
    bool isFatigued;

    bool isRunning;

   



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
        MovePlayer();

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
            audioSource.enabled = true;
            
        }
        else
        {
            audioSource.enabled = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0 && !isFatigued)
            {
               // float newSpeed = 1.2f;
               // audioSource.pitch = newSpeed;
               // audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / newSpeed);
                moveSpeed = runSpeed;
                isRunning = true;
            }
            else

            if (isRunning || isFatigued)
            { moveSpeed = walkSpeed; isRunning = false; }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        { if (isRunning || isFatigued)
            { moveSpeed = walkSpeed; isRunning = false; } }

        if (isRunning)
        {stamina -= Time.deltaTime * drainRate; }
        else
        if (!isRunning && stamina > 0 && stamina < 100)
        { stamina += Time.deltaTime * reChargeRate; }

        if (stamina <= 0f && fatigueTimer <= 3)
        { fatigueTimer += Time.deltaTime;
            isFatigued = true;}
        else
        if (fatigueTimer >= 3)
        { stamina += Time.deltaTime * reChargeRate;
            isFatigued = false;
            fatigueTimer = 0;}

        if (stamina < 0f)
        { stamina = 0f;}
        if (stamina > 100f)
        { stamina = 100f; }

       


    }

    private void FixedUpdate()
    {
       
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

    

}
