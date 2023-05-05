using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamPan : MonoBehaviour
{
    // Adjust the speed for the application.
    public float speed = 10f;

    // The target (cylinder) position.
    public Transform target;

    public bool steve;
    void Awake()
    {

        StartCoroutine(Pan());

        
        
        //target.transform.position = new Vector3(51.42f, -13.2f, 107.19f);

        

       
    }

    void Update()
    {
        // Move our position a step closer to the target.
        if(steve == true)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        



    }

    IEnumerator Pan()
    {
        yield return new WaitForSeconds(3f);
        steve = true;
        

    }
}
