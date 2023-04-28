using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition + new Vector3(10.0f,0.0f,0.0f);
    }
}
