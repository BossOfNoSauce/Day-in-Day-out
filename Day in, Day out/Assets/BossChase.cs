using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FirstPersonCameraRotation firstPersonCamera;

    public GameObject Boss;
    public GameObject Camera;
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
       

    }

    IEnumerator Stare()
    {
        playerMovement.InGame = true;
        firstPersonCamera.FreezeMovement = true;
        Camera.transform.LookAt(Boss.transform.position, Vector3.up);

        yield return new WaitForSeconds(10);

    }
}
