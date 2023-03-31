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
    float thecube;
    public bool GameIsActive = true;

    public Rigidbody m_rigidbody;
    public float m_Thrust = 5f;

    void Start()
    {
        horizontalInput = Input.GetAxisRaw("horizontalcool");
        pointA = new Vector3(65, 8, 12);
        pointB = new Vector3(100, 8, 12);
        //thecube = transform.position.x + (horizontalInput * speed2);
    }

    void Update()
    {
        StartCoroutine(MoveObj());
        Debug.Log(thecube);
       // transform.position = new Vector3(thecube,8,12);

    }

    IEnumerator MoveObj()
    {
        while (GameIsActive == true)
        {
            m_rigidbody.AddForce(transform.right * m_Thrust);
            yield return new WaitForSeconds(1);
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.AddForce(-transform.right * m_Thrust);
            yield return new WaitForSeconds(1);
            m_rigidbody.velocity = Vector3.zero;
        }
        




        //PingPong between 0 and 1
        //float time = Mathf.PingPong(Time.time * speed, 1);
        //transform.position = Vector3.Lerp(pointA, pointB, time);
    }

    void Move()
    {
      
    }



    //have control over object

    // if z position is over certain threshold, fail state
}
