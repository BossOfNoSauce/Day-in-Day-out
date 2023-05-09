using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPos : MonoBehaviour
{
    public GameObject Coffee;
    public GameObject Noodles;
    public GameObject Mug;

    public KitchenObjs kitchenObjs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coffee")
        {
            Coffee.transform.localPosition = new Vector3(34, 1, -66);
            kitchenObjs.GrabBool = false;
            kitchenObjs.simDrop();
        }

        if (other.gameObject.tag == "Noodles")
        {
            Noodles.transform.localPosition = new Vector3(35, 4.5f, -68);
            kitchenObjs.GrabBool = false;
            kitchenObjs.simDrop();
        }

        if (other.gameObject.tag == "Mug")
        {
            Mug.transform.localPosition = new Vector3(34, 1.5f, -61);
            kitchenObjs.GrabBool = false;
            kitchenObjs.simDrop();
        }
    }
}
