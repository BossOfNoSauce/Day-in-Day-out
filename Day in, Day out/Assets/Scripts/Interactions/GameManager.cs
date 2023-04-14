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
    public IEnumerator IntroCutscene()
    {
        if(TheBool == false)
        {
            TheBool = true;
            yield return new WaitForSeconds(2);
            audioSource.PlayOneShot(Dialogue, 0.7F);
            yield return new WaitForSeconds(4.5f);
            textBox.GetComponent<Text>().text = "Hey... *uh* Bad news mate ";
            yield return new WaitForSeconds(2);
            textBox.GetComponent<Text>().text = "so *like* Apparently our stocks have gone down";
            yield return new WaitForSeconds(2.5f);
            textBox.GetComponent<Text>().text = "like, way, way down";
            yield return new WaitForSeconds(2.8f);
            textBox.GetComponent<Text>().text = "and it's supposedly because everyone hasn't been doing *like*";
            yield return new WaitForSeconds(3);
            textBox.GetComponent<Text>().text = "anything";
            yield return new WaitForSeconds(2);
            textBox.GetComponent<Text>().text = "so now the boss is pretty *uh* peeved off and has made some harsh polices to";
            yield return new WaitForSeconds(5.8f);
            textBox.GetComponent<Text>().text = "y'know *uh* weed out the slackers";
            yield return new WaitForSeconds(3.5f);
            textBox.GetComponent<Text>().text = "so now everyone has to complete a consistent percentage of work and turn it into the boss at the end of the day";
            yield return new WaitForSeconds(5.5f);
            textBox.GetComponent<Text>().text = "pretty inconvenient if you ask me ";
            yield return new WaitForSeconds(1.5f);
            textBox.GetComponent<Text>().text = "I would file a complaint but I *uh* really don't wanna get on the big guy's bad side ";
            yield return new WaitForSeconds(5.5f);
            textBox.GetComponent<Text>().text = "Here... ";
            yield return new WaitForSeconds(3.5f);
            textBox.GetComponent<Text>().text = "Just *uh* write your junk in that and turn it in at the end of the day ";
            yield return new WaitForSeconds(4);
            textBox.GetComponent<Text>().text = "Just trying to make sure you don't get in trouble, I'll let you get back to your... *uh* ";
            yield return new WaitForSeconds(5);
            textBox.GetComponent<Text>().text = "whatever you're doing... ";
            yield return new WaitForSeconds(2);
            textBox.GetComponent<Text>().text = " ";
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(door, 0.7f);
            animator.SetTrigger("Open");
            jukebox.startMus = true;
            
        }
        

    }

    public void dumb()
    {
          StartCoroutine(IntroCutscene());
        
    }

}
