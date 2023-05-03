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
    public float Power;
    public bool velocityActive = true;
    public bool GameOver = false;
    //ui thing
    public GameObject urinalArrow;
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
                int temp = Random.Range(0, 1);
                int temp2;
                if(temp > 0)
                {
                    temp2 = 1;
                }
                else
                {
                    temp2 = -1;
                }
                //m_rigidbody.velocity = -1 * Mathf.Sign(m_rigidbody.velocity.x) * (temp > 0 ? right:-right);//added random left / right swing
                //urinalArrow.transform.rotation.Set(0.0f, 180.0f * temp2, 0.0f, urinalArrow.transform.rotation.w);
                //Debug.Log(urinalArrow.transform.rotation.y);
                time = 0f;
                Dafunk();
            }
        }
        if(GameOver== true || GameFail == true)
        {
            m_rigidbody.velocity = Vector3.zero;
        }


        if(GameIsActive == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                m_rigidbody.AddForce(Vector3.right * Power);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                m_rigidbody.AddForce(-Vector3.right * Power);
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)//fail game
    {
        Debug.Log("game fail in urinal, attemting end game");
        GameFail = true;
        GameOver = true;
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
