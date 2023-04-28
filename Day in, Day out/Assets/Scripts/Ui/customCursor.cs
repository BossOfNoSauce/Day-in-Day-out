using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
