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

    public GameObject ToDoUi;

    public GameObject BossImage;
    public  AudioSource audioSource;
    public AudioClip day1monologue;
    public AudioClip day2monologue;
    public AudioClip day3monologue;
    public AudioClip day4monologue;
    public AudioClip Finalmonologue;

    public AudioClip Buzzer;
    public GameObject textBox;

    public GameObject JukeBoxObj;
    Jukebox jukebox;

    public Animator elevator;
    public AudioClip OpeningElevator;

    public Collider Mcollider;
    public Collider AnimTrigger;

    public GameObject BossDoor;

    public GameObject computerui;
    public GameObject urinalui;
    public GameObject breakroomui;
    public GameObject meetingui;
    public GameObject bossui;
    public GameObject elevatorui;
    

    public GameObject button;

    public SubtitleManager subtitle;
    public Animator BossDoorAnim;
    // Start is called before the first frame update
    void Start()
    {
        daySystem = DayManager.GetComponent<DaySystem>();
        jukebox = JukeBoxObj.GetComponent<Jukebox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (daySystem.ComputerIsDone == true && daySystem.BossCooldown == false)
        {
            if (daySystem.Days == 1)
            {
                computerui.SetActive(false);
                bossui.SetActive(true);
            }    
        }

        if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.BossCooldown == false)
        {
            if (daySystem.Days == 2)
            {
                computerui.SetActive(false);
                urinalui.SetActive(false);
                bossui.SetActive(true);
            }
        }

        if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.kitchenIsWin == true && daySystem.BossCooldown == false)
        {
            if (daySystem.Days == 3)
            {
                computerui.SetActive(false);
                urinalui.SetActive(false);
                breakroomui.SetActive(false);
                bossui.SetActive(true);
            }
        }

        if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.KitchenIsDone == true && daySystem.meetingIsWin == true && daySystem.BossCooldown == false)
        {
            if (daySystem.Days == 4)
            {
                computerui.SetActive(false);
                urinalui.SetActive(false);
                breakroomui.SetActive(false);
                meetingui.SetActive(false);
                bossui.SetActive(true);
            }
        }
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("interacted");
        StartCoroutine(Boss());

        return true;
    }

    public IEnumerator Boss()
    {
        bossui.SetActive(false);
        computerui.SetActive(false);
        urinalui.SetActive(false);
        breakroomui.SetActive(false);
        meetingui.SetActive(false);
        elevatorui.SetActive(true);
        if (daySystem.Days == 1)
        {
            if ( daySystem.BossCooldown == false && daySystem.ComputerIsDone == true)
            {
                
                daySystem.BossCooldown = true;
                AnimTrigger.enabled = false;
                Mcollider.enabled = true;
                ToDoUi.SetActive(false);
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                yield return new WaitForSeconds(1);
                audioSource.PlayOneShot(day1monologue, 2);
                StartCoroutine(subtitle.Boss1());
                yield return new WaitForSeconds(37);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
                
                ToDoUi.SetActive(true);
                daySystem.cooldown = false;

                elevator.SetTrigger("Elevator Open");
                audioSource.PlayOneShot(OpeningElevator);
                Mcollider.enabled = false;
            }

            else if (daySystem.BossCooldown == true)
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }


        if (daySystem.Days == 2)
        {
            
            if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.BossCooldown == false)
            {
                daySystem.BossCooldown = true;
                AnimTrigger.enabled = false;
                Mcollider.enabled = true;
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                ToDoUi.SetActive(false);
                audioSource.PlayOneShot(day2monologue, 1);
                StartCoroutine(subtitle.Boss2());
                yield return new WaitForSeconds(37);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
                ToDoUi.SetActive(true);
                daySystem.cooldown = false;
                elevator.SetTrigger("Elevator Open");
                audioSource.PlayOneShot(OpeningElevator);
                Mcollider.enabled = false;
            }
            if (daySystem.computerIsWin == false || daySystem.urinalIsWin == false)
            {
                StopCoroutine(Boss());
                daySystem.temp = true;
            }

            else if (daySystem.BossCooldown == true)
            {
                audioSource.PlayOneShot(Buzzer);

            }
        }

        if (daySystem.Days == 3)
        {
            
            if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.kitchenIsWin == true && daySystem.BossCooldown == false)
            {

                daySystem.BossCooldown = true;
                AnimTrigger.enabled = false;
                Mcollider.enabled = true;
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                ToDoUi.SetActive(false);
                audioSource.PlayOneShot(day3monologue, 1);
                StartCoroutine(subtitle.Boss3());
                yield return new WaitForSeconds(25);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
                ToDoUi.SetActive(true);
                daySystem.cooldown = false;
                elevator.SetTrigger("Elevator Open");
                audioSource.PlayOneShot(OpeningElevator);
                Mcollider.enabled = false;
            }
            if (daySystem.computerIsWin == false || daySystem.urinalIsWin == false || daySystem.kitchenIsWin == false)
            {
                StopCoroutine(Boss());
                daySystem.temp = true;
            }
            else if (daySystem.BossCooldown == true)
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }


        if (daySystem.Days == 4)
        {
            
            if (daySystem.computerIsWin == true && daySystem.urinalIsWin == true && daySystem.KitchenIsDone == true && daySystem.meetingIsWin == true && daySystem.BossCooldown == false)
            {
                daySystem.BossCooldown = true;
                AnimTrigger.enabled = false;
                Mcollider.enabled = true;
                jukebox.StopMus();
                jukebox.startMus = false;
                BossImage.SetActive(true);
                ToDoUi.SetActive(false);
                audioSource.PlayOneShot(day4monologue, 1);
                StartCoroutine(subtitle.Boss4());
                yield return new WaitForSeconds(29);
                daySystem.BossCheck = true;
                Debug.Log(daySystem.BossCheck);
                BossImage.SetActive(false);
                daySystem.BossCooldown = true;
                bossui.SetActive(false);
                elevatorui.SetActive(true);
                
                ToDoUi.SetActive(true);
                daySystem.cooldown = false;
                elevator.SetTrigger("Elevator Open");
                audioSource.PlayOneShot(OpeningElevator);
                daySystem.BossCooldown = true;
                Mcollider.enabled = false;
            }
            if (daySystem.computerIsWin == false || daySystem.urinalIsWin == false || daySystem.kitchenIsWin == false || daySystem.meetingIsWin == false)
            {
                StopCoroutine(Boss());
                daySystem.temp = true;
            }
            else if (daySystem.BossCooldown == true)
            {
                audioSource.PlayOneShot(Buzzer);
            }
        }

        if(daySystem.Days == 5)
        {
           
            if (daySystem.AbleToChase == true)
            {
                Mcollider.enabled = true;
                BossImage.SetActive(true);
                ToDoUi.SetActive(false);
                audioSource.PlayOneShot(Finalmonologue, 1);
                StartCoroutine(subtitle.Boss5());
                yield return new WaitForSeconds(20); // Number is not confirmed, dependant on sound file
                ToDoUi.SetActive(true);
                BossImage.SetActive(false);
                elevatorui.SetActive(false);
                computerui.SetActive(false);
                urinalui.SetActive(false);
                bossui.SetActive(true);
                BossDoorAnim.SetTrigger("BossOpen");
                // swing open door
            }
        }

        yield return new WaitForSeconds(1);
    }
    
}
