using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToDo : MonoBehaviour
{
    //to-do
    //[]set tab to show/hide the todo list ui element by sliding
    //[]bool do enable/dissable input
    //public vars
    public bool canOpen = true;
    public float revealPos = -50.0f;
    public float hiddenPos = -550.0f;
    public float speed = 10.0f;
    //needed items
    RectTransform rect;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Tab) && canOpen)
        {
            if(rect.anchoredPosition.y < revealPos)
            {
                rb.velocity = new Vector3(0.0f, speed, 0.0f);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            Debug.Log(rect.anchoredPosition.y + ", " + hiddenPos);
            if (rect.anchoredPosition.y > hiddenPos)
            {
                rb.velocity = new Vector3(0.0f, -speed, 0.0f);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
