using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FirstPersonCameraRotation firstPersonCamera;

    public GameObject Boss;
    public GameObject Camera;

    public float xAngle, yAngle, zAngle;

    public Rigidbody rb;
    public float Power;

    public float speed;
    public Collider trigger;

    public AudioSource audioSource;
    public AudioClip BigMonologue;
    public bool startChase;
    public AudioClip Roar;

    public AudioClip ChaseMusic;

    public GameObject target;
    public Transform player;

    public bool turnCooldown;


    public Transform[] Points;
    public float moveSpeed;
    public int pointsIndex;





    //map objects
    public GameObject debris;
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startChase == false)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(targetPosition);

            transform.rotation.Set(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
        }







        if (startChase == true)
        {
            if (pointsIndex <= Points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
                if (transform.position == Points[pointsIndex].transform.position)
                {
                    pointsIndex += 1;
                }
            }
            //StartCoroutine(MoveTowards());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            trigger.enabled = false;
            StartCoroutine(Stare());
        }
        
       
    }

    IEnumerator Stare()
    {
        playerMovement.InGame = true;
        firstPersonCamera.FreezeMovement = true;
        Camera.transform.LookAt(Boss.transform.position, Vector3.up);
        audioSource.PlayOneShot(BigMonologue, 1f);
        debris.SetActive(true);
       // yield return new WaitForSeconds(38);
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        audioSource.PlayOneShot(Roar);
        yield return new WaitForSeconds(5);
        audioSource.PlayOneShot(ChaseMusic);
        startChase = true;

    }

    public IEnumerator MoveTowards()
    {

        yield return new WaitForSeconds(1);







       /* transform.Translate(Vector3.forward * Time.deltaTime * speed);
        yield return new WaitForSeconds(3);
        transform.Translate(0, 0, 0);
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        transform.Translate(Vector3.forward * Time.deltaTime * speed); // first turn
        yield return new WaitForSeconds(4);
        
        transform.Translate(0, 0, 0);
       
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);// second turn */




    }


}
