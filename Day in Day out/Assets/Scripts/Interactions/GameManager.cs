using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameActive;
    public AudioSource audioSource;
    public AudioClip Dialogue;
    public Animator animatorDoor;
    public AudioClip door;
    //audio
    public GameObject JukBox;
    Jukebox jukebox;
    //minigame bool
    public Computer computer;
    //bools
    public bool bookPickup;
    public bool oneShot = false;
    bool sceneOver = false;
    bool doorOneShot = true;
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
        if (sceneOver && bookPickup && doorOneShot)
        {
            doorOneShot = false;
            audioSource.PlayOneShot(door, 0.7f);
            animatorDoor.SetTrigger("Open");
            jukebox.startMus = true;
            computer.TheFunnyBool = true;
        }
    }
    //Intro cutscene
    public IEnumerator IntroCutscene()
    {
        if(oneShot == false)
        {
            oneShot = true;
            yield return new WaitForSeconds(8);
            audioSource.PlayOneShot(Dialogue, 0.7F);
            StartCoroutine(subtitle.intro());
            yield return new WaitForSeconds(53);
            sceneOver = true;
        }
        

    }

    public void dumb()
    {
          StartCoroutine(IntroCutscene());
        
    }

}
