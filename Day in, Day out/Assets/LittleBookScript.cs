using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBookScript : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public float speed = 10f;
    public GameObject ToDoUI;
    public GameObject ComUI;
    public GameObject PeeUI;
    public GameObject KitUI;
    public GameObject MetUI;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        ToDoUI.SetActive(true);
        ComUI.SetActive(true);
        PeeUI.SetActive(false);
        KitUI.SetActive(false);
        MetUI.SetActive(false);
        gameObject.SetActive(false);
        


        return true;
    }

    public void Slide()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
