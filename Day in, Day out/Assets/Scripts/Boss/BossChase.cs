using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FirstPersonCameraRotation firstPersonCamera;

    public GameObject Boss;
    public GameObject Camera;

    public Rigidbody rb;
    public float Power;

    public float speed;
    public Collider trigger;

    public AudioSource audioSource;
    public AudioClip BigMonologue;
    public bool startChase;
    public AudioClip Roar;

    public GameObject target;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);

        transform.rotation.Set(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);





        if (startChase == true)
        {
            StartCoroutine(MoveTowards());
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
       // yield return new WaitForSeconds(38);
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        audioSource.PlayOneShot(Roar);
        yield return new WaitForSeconds(5);
        startChase = true;

    }

    public IEnumerator MoveTowards()
    {

    
        yield return new WaitForSeconds(3);
      


    }
}
