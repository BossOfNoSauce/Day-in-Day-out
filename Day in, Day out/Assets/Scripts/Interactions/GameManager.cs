using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameActive;
    public AudioSource audioSource;
    public AudioClip Dialogue;
    public Animator animator;
    public AudioClip door;
    public bool TheBool;
    public TMP_Text textBox;
    public GameObject textobj;


    public GameObject JukBox;
    Jukebox jukebox;

    public bool StartGame;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        jukebox = JukBox.GetComponent<Jukebox>();
        textBox = textobj.GetComponent<TMPro.TextMeshProUGUI>();
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
            yield return new WaitForSeconds(2);
            //textBox.GetComponent<Text>().text = "Hey...";
            textBox.text = "Hey ... ";
            yield return new WaitForSeconds(52);
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
