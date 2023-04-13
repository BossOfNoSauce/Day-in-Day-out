using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameActive;
    public AudioSource audioSource;
    public AudioClip Dialogue;
    public Animator animator;

    public GameObject JukBox;
    Jukebox jukebox;

    public bool StartGame;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        jukebox = JukBox.GetComponent<Jukebox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Intro cutscene
    public IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(Dialogue);
        yield return new WaitForSeconds(52);
        animator.SetTrigger("Interact");
        jukebox.startMus = true;

    }

    public void dumb()
    {
          StartCoroutine(Cutscene());
        
    }

}
