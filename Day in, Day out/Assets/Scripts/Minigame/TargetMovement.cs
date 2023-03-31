using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float speed = 0.15f;
   
   
    float horizontalInput;
    
    public float swayTime = 5f;
    public float time = 0f;
    public bool GameIsActive = true;
    public Vector3 right;
    public Rigidbody m_rigidbody;
   

    void Start()
    {
        time = swayTime / 2;

        horizontalInput = Input.GetAxisRaw("horizontalcool");
        
        

        m_rigidbody.velocity = right;
    }

    void Update()
    {
        if(GameIsActive == true)
        {
            time += Time.deltaTime;
            if (time > swayTime)
            {
                m_rigidbody.velocity = -1 * Mathf.Sign(m_rigidbody.velocity.x) * right;
                time = 0f;
            }
        }
       
     
      //set barriers that when on collided, it game overs.

      //have arrow keys add force to the cube;

    }

    

   



}
