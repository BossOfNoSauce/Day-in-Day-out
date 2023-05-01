using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamPan : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 10f;

    // The target (cylinder) position.
    public Transform target;

    void Awake()
    {
      
       

        
        
        target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);

        

       
    }

    void Update()
    {
        // Move our position a step closer to the target.
        //var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position);

        // Check if the position of the cube and sphere are approximately equal.
       // if (Vector3.Distance(transform.position, target.position) < 0.001f)
       // {
            // Swap the position of the cylinder.
       //     target.position *= -1.0f;
      // }
    }
}
