using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour, Iinteractable
{
    public GameObject target;
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public AudioSource audioSource;

    public AudioClip[] audioClips;

    
    public FaceCamera(GameObject target)
    {
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);

        transform.rotation.Set(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);//rotation correcting, the x and z rot shouldnt be modified so set to 0

        
    }

    public bool Interact(Interactor interactor)
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        return true;
    }

}

