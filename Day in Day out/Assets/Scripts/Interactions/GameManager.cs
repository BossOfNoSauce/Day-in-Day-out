using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameActive;
    public AudioSource audioSource;
    public AudioClip Dialogue;
    public Animator animator;
    public AudioClip door;
    public bool TheBool;
    public GameObject textBox;

    public GameObject JukBox;
    Jukebox jukebox;
    public Computer computer;
    
    public bool StartGame;


    public SubtitleManager subtitle;
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
    public IEnumerator IntroCutscene()
    {
        if(TheBool == false)
        {
            
            TheBool = true;
            //computer.canCompute = false;
            yield return new WaitForSeconds(8);
            audioSource.PlayOneShot(Dialogue, 0.7F);
            StartCoroutine(subtitle.intro());
            yield return new WaitForSeconds(53);
            audioSource.PlayOneShot(door, 0.7f);
            animator.SetTrigger("Open");
            jukebox.startMus = true;
            computer.TheFunnyBool = true;
            
        }
        

    }

    public void dumb()
    {
          StartCoroutine(IntroCutscene());
        
    }

}
