using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 0.15f;
    public float speed2 = 0.2f;
    Vector3 pointA;
    Vector3 pointB;
    float horizontalInput;


    void Start()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal2");
        pointA = new Vector3(65, 8, 12);
        pointB = new Vector3(100, 8, 12);
    }

    void Update()
    {
        //MoveObj();
        transform.position = new Vector3(transform.position.x + (horizontalInput * speed2),8,12);

    }

    void MoveObj()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }

    void Move()
    {
      
    }



    //have control over object

    // if z position is over certain threshold, fail state
}
