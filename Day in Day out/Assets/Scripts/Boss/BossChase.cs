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


    //debrie and stuff
    public GameObject debris;
    public GameObject barrir;
    public GameObject debrisTrigger;
    //stuff to dissable
    public GameObject desks;
    public GameObject Sofa;
    public GameObject Benches;

    public GameObject ChaseDoor;

    public Animator BossAnim;

    public GameObject Crash1;
    public GameObject Crash2;

    public GameObject Barrier;
    public GameObject Barrier2;
    public GameObject Barrier3;

    public GameObject Door;

    public SubtitleManager subtitle;

    public AudioSource Boss2;

    public GameObject Barrys;

    public GameObject taskUI;
    public GameObject eleUI;
    public GameObject bossUI;
    public GameObject getOutUi;

    public AudioClip Crash;
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
            if(startChase == false)
            {
                Debug.Log("im triggering the big one");
                trigger.enabled = false;
                barrir.SetActive(true);
                StartCoroutine(Stare());
            }
           
        }


    }

    IEnumerator Stare()
    {
        taskUI.SetActive(false);
        playerMovement.InGame = true;
        firstPersonCamera.FreezeMovement = true;
        Camera.transform.LookAt(Boss.transform.position, Vector3.up);
        audioSource.PlayOneShot(BigMonologue, 1f);
        StartCoroutine(subtitle.BossEnd());
        yield return new WaitForSeconds(3);
        BossAnim.SetTrigger("Turn");
        Barrier.SetActive(true);
        Door.SetActive(true);
        Barrier2.SetActive(true);
        Barrier3.SetActive(true);
        debrisTrigger.SetActive(true);
        //show debris
        debris.SetActive(true);
        //hide normal stuff
        desks.SetActive(false);
        Sofa.SetActive(false);
        Benches.SetActive(false);
        ChaseDoor.SetActive(false);
        Barrys.SetActive(true);
        yield return new WaitForSeconds(35);
        taskUI.SetActive(true);
        bossUI.SetActive(false);
        eleUI.SetActive(true);
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        audioSource.PlayOneShot(Roar);
        BossAnim.SetTrigger("Roar");
        yield return new WaitForSeconds(5);
        elevator.SetTrigger("Elevator Open");
        audioSource.PlayOneShot(OpeningElevator);
        BossAnim.SetTrigger("Run");
        startChase = true;
        getOutUi.SetActive(true);
        audioSource.PlayOneShot(ChaseMusic);
        yield return new WaitForSeconds(4.75f);
        audioSource.Play();
        Boss2.enabled = true;

    }

    public IEnumerator MoveTowards()
    {

        yield return new WaitForSeconds(3);
        Crash1.SetActive(true);
        audioSource.PlayOneShot(Crash);
        yield return new WaitForSeconds(70);
        Crash2.SetActive(true);
        audioSource.PlayOneShot(Crash);










    }

    
    public void ResetChase()
    {
        Barrier.SetActive(false);
        Door.SetActive(false);
        Barrier2.SetActive(false);
        Barrier3.SetActive(false);
        debrisTrigger.SetActive(false);
    }

}
