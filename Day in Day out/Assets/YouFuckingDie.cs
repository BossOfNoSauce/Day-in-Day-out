using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouFuckingDie : MonoBehaviour
{
    public GameObject player;
    public GameObject Camera;

    public PlayerMovement playerMovement;
    public FirstPersonCameraRotation firstPersonCamera;

    public Animator animator;

    public Animator elevator;

    public AudioSource audioSource;

    public AudioClip OpeningElevator;

    public GameObject Teeny;

    public BossChase bossChase;

    public AudioSource BossSource;

    public Collider bossTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "SubBoss")
            {
                if(bossChase.startChase == true)
                {
                    StartCoroutine(Death());
                    //death stuff
                }

            }

        }
    }

    public IEnumerator Death()
    {
        playerMovement.InGame = true;
        firstPersonCamera.FreezeMovement = true;
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Ftb");
        //you died text
        player.transform.position = new Vector3(142, 7.4f, -43f);
        yield return new WaitForSeconds(3);
        animator.SetTrigger("fob");
        elevator.SetTrigger("Elevator Open");
        audioSource.PlayOneShot(OpeningElevator);
        bossChase.startChase = false;
        BossSource.Stop();
        bossTrigger.enabled = true;
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        //reset the boss chase so you dont just end the game



    }
}
