using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public bool startMus;
    public AudioSource audioSource;

    public AudioClip[] audioClips;

    public AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startMus == true)
        {
            if (!audioSource.isPlaying)
            {
                PlayRandom();
            }
        }
       

    }

    //Play random song in array
    void PlayRandom()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

}