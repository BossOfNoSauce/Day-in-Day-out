using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAND : MonoBehaviour
{
    public bool HandActive = true;

    Vector3 pos;

    public float offset = 3f;

    public Color[] colors;

   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if(HandActive == true)
        {
            

            pos = Input.mousePosition;

            pos.z = offset;

            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }

        

    }
}
