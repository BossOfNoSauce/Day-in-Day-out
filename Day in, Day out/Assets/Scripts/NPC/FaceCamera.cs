using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(camera.transform.position.x, transform.position.y, camera.transform.position.z);

        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}