using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLegion : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public DaySystem ds;

    public GameObject eye;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ds.Days == 5)
        {
            eye.SetActive(true);
            
        }
    }

    public bool Interact(Interactor interactor)
    {
       if(ds.Days == 5)
        {
            
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }

        return true;
    }
}
