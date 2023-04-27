using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;

    public string InteractionPrompt => prompt;

    public GameObject DayManager;
    DaySystem daySystem;

    public GameObject jukeBox;
    Jukebox jukebox;

    public GameObject BossImage;
    public  AudioSource audioSource;
    public AudioClip day1monologue;
    public AudioClip Buzzer;
    // Start is called before the first frame update
    void Start()
    {
        daySystem = DayManager.GetComponent<DaySystem>();
        jukebox = jukeBox.GetComponent<Jukebox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("interacted");
        StartCoroutine(Boss());
        return true;
    }

    public IEnumerator Boss()
    {
        
        if (daySystem.ComputerIsDone == true && daySystem.Days == 1)
        {
            jukebox.StopMusic();
            BossImage.SetActive(true);
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(day1monologue, 1);
            yield return new WaitForSeconds(34);
            daySystem.BossCheck = true;
            Debug.Log(daySystem.BossCheck);
            BossImage.SetActive(false);
        }
       // else
       // {
       //     audioSource.PlayOneShot(Buzzer);
       // }
       // yield return new WaitForSeconds(1);
    }

    
}
