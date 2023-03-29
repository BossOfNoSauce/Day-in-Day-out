using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float rotDuration;
    private float rotTimer = 0f;
    public bool rotRight = true;
    public float rotSpeed = 1f;

    public float xRotation;
    public float yRotation;

    public float mouseX;
    public float mouseY;

    public Transform orientation;

    public bool gameStateisactive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fucktion();
    }

    void fucktion()
    {
        while(gameStateisactive == true)
        {
            Debug.Log("fart");
            yRotation++;

            xRotation++;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

       
    }
}

