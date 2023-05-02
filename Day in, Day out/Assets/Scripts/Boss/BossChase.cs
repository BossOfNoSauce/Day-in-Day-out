using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FirstPersonCameraRotation firstPersonCamera;

    public GameObject Boss;
    public GameObject Camera;

    public AudioSource audioSource;
    public AudioClip BigMonologue;
    public bool startChase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startChase == true)
        {
            MoveTowards();
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        StartCoroutine(Stare());
       
    }

    IEnumerator Stare()
    {
        playerMovement.InGame = true;
        firstPersonCamera.FreezeMovement = true;
        Camera.transform.LookAt(Boss.transform.position, Vector3.up);
        audioSource.PlayOneShot(BigMonologue, 1f);
        yield return new WaitForSeconds(10);
        playerMovement.InGame = false;
        firstPersonCamera.FreezeMovement = false;
        yield return new WaitForSeconds(5);
        startChase = true;

    }

    public void MoveTowards()
    {
     
    }
}
