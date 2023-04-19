using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 0.15f;
    
   
    float horizontalInput;

    public float swayTime = 5f;
    float time = 0f;
    public bool GameIsActive = false;
    public Vector3 right;
    public Rigidbody m_rigidbody;
    public bool GameFail = false;
    public float Power = 20f;
    public bool velocityActive = true;
    public bool GameOver = false;
    

    void Start()
    {
        time = swayTime / 2;
        horizontalInput = Input.GetAxisRaw("horizontalcool");
        
    }

    void Update()
    {
        time += Time.deltaTime;
        
        if (GameIsActive == true )
        {
            Dafunk();
            if (time > swayTime)
            {
                m_rigidbody.velocity = -1 * Mathf.Sign(m_rigidbody.velocity.x) * right;
                time = 0f;
                Dafunk();
            }
        }
        if(GameOver== true)
        {
            m_rigidbody.velocity = Vector3.zero;
        }

        if (GameFail == true)
        {
            m_rigidbody.velocity = Vector3.zero;
        }


        if(GameIsActive == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_rigidbody.AddForce(Vector3.right * Power);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_rigidbody.AddForce(-Vector3.right * Power);
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        GameFail = true;
        Debug.Log(GameFail);
    }

    void Dafunk()
    {
        if(velocityActive == true)
        {
            m_rigidbody.velocity = right;
            velocityActive = false;
        }
    }

   




}
