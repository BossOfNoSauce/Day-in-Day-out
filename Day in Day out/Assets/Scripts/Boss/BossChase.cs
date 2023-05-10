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


    public GameObject[] Points;
    public int numberOfPoints;
    public float moveSpeed;

    private int pointsIndex;
    private Vector3 position;

    public Animator elevator;
    public AudioClip OpeningElevator;


    //map objects
    public GameObject debris;

    public GameObject desks;
    public GameObject StrewnDesks;
    public GameObject Sofa;
    public GameObject SofaDeeznuts;
    public GameObject Benches;
    public GameObject StrewnBenches;

    public GameObject debrisTrigger;

    public GameObject ChaseDoor;

    public Animator BossAnim;

    public GameObject Crash1;
    public GameObject Crash2;
    void Start()
    {
        //transform.position = Points[pointsIndex].transform.position;
        pointsIndex = 1;
        BossAnim.SetTrigger("Back");
    }

    // Update is called once per frame
    void Update()
    {
        
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(targetPosition);

            transform.rotation.Set(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
        







        if (startChase == true)
        {
            


            position = Boss.transform.position;
            Boss.transform.position = Vector3.MoveTowards(position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if(position == Points[pointsIndex].transform.position && pointsIndex != numberOfPoints - 1)
            {
                pointsIndex++;
            }

            
            
            /*if (pointsIndex <= Points.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
                if (transform.position == Points[pointsIndex].transform.position)
                {
                    pointsIndex += 1;
                }
            }*/
            StartCoroutine(MoveTowards());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
        yield return new WaitForSeconds(3);
        BossAnim.SetTrigger("Turn");

        debrisTrigger.SetActive(true);
        debris.SetActive(true);
        desks.SetActive(false);
        StrewnDesks.SetActive(true);
        Sofa.SetActive(false);
        SofaDeeznuts.SetActive(true);
        Benches.SetActive(false);
        StrewnBenches.SetActive(true);
        ChaseDoor.SetActive(false);
        yield return new WaitForSeconds(35);
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        audioSource.PlayOneShot(Roar);
        BossAnim.SetTrigger("Roar");
        yield return new WaitForSeconds(5);
        elevator.SetTrigger("Elevator Open");
        audioSource.PlayOneShot(OpeningElevator);
        audioSource.PlayOneShot(ChaseMusic);
        BossAnim.SetTrigger("Run");
        startChase = true;

    }

    public IEnumerator MoveTowards()
    {

        yield return new WaitForSeconds(3);
        Crash1.SetActive(true);
        yield return new WaitForSeconds(76);
        Crash2.SetActive(true);






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
