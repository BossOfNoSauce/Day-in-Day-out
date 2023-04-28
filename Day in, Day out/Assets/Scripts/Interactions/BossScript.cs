using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour, Iinteractable
{
    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;

    public GameObject DayManager;
    DaySystem daySystem;

    public GameObject BossImage;
    public  AudioSource audioSource;
    public AudioClip day1monologue;
    public AudioClip day2monologue;
    public AudioClip day3monologue;
    public AudioClip day4monologue;

    public AudioClip Buzzer;
    public GameObject textBox;

    public GameObject JukeBoxObj;
    Jukebox jukebox;
    // Start is called before the first frame update
    void Start()
    {
        daySystem = DayManager.GetComponent<DaySystem>();
        jukebox = JukeBoxObj.GetComponent<Jukebox>();
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
        
        if (daySystem.Days == 1)
        {
            if (daySystem.ComputerIsDone == true && daySystem.BossCooldown == false)
            {
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(day1monologue, 1);
                yield return new WaitForSeconds(1);
                textBox.GetComponent<Text>().text = "Well, well, well, look who we got here";
                yield return new WaitForSeconds(3);
                textBox.GetComponent<Text>().text = "Good to see you kid";
                yield return new WaitForSeconds(1.5f);
                textBox.GetComponent<Text>().text = "Outta everyone is this office, you was the one I was the least worried about";
                yield return new WaitForSeconds(4);
                textBox.GetComponent<Text>().text = "Don't worry about turnin' in your book";
                yield return new WaitForSeconds(1.7f);
                textBox.GetComponent<Text>().text = "I trust ya enough that you're not gonna toss it or somethin'";
                yield return new WaitForSeconds(3);
                textBox.GetComponent<Text>().text = "But, I must say, I apologize for pushing these new rules on ya kid";
                yield return new WaitForSeconds(4);
                textBox.GetComponent<Text>().text = "Our business, is frankly in disarray";
                yield return new WaitForSeconds(3);
                textBox.GetComponent<Text>().text = "Because this establishment is full of";
                yield return new WaitForSeconds(2);
                textBox.GetComponent<Text>().text = "LAZY";
                yield return new WaitForSeconds(1);
                textBox.GetComponent<Text>().text = "GOOD FOR NOTHING";
                yield return new WaitForSeconds(1);
                textBox.GetComponent<Text>().text = "MALINGERERS";
                yield return new WaitForSeconds(1.5F);
                textBox.GetComponent<Text>().text = "I gotta do what I gotta do, for the greater good of this company";
                yield return new WaitForSeconds(3.5f);
                textBox.GetComponent<Text>().text = "So, you keep up the good work kid, and don't dissappoint me";
                yield return new WaitForSeconds(4);
                textBox.GetComponent<Text>().text = " ";
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
            }
            else
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }


        if (daySystem.Days == 2)
        {
            if (daySystem.ComputerIsDone == true && daySystem.UrinalIsDone == true && daySystem.BossCooldown == false)
            {
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(day2monologue, 1);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
            }
            else
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }

        if (daySystem.Days == 3)
        {
            if (daySystem.ComputerIsDone == true && daySystem.UrinalIsDone == true && daySystem.KitchenIsDone == true && daySystem.BossCooldown == false)
            {
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(day2monologue, 1);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
            }
            else
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }


        if (daySystem.Days == 4)
        {
            if (daySystem.ComputerIsDone == true && daySystem.UrinalIsDone == true && daySystem.KitchenIsDone == true && daySystem.MeetingIsDone == true && daySystem.BossCooldown == false)
            {
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(day2monologue, 1);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
            }
            else
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }

        yield return new WaitForSeconds(1);
    }
    
}
