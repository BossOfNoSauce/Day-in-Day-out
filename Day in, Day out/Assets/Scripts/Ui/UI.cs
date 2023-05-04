using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    public Transform target;
    public bool john;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip Music;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Title());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CameraMove());
            
            

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    IEnumerator Title()
    {
        yield return new WaitForSeconds(4);
        animator.SetTrigger("CameraMove");
        yield return new WaitForSeconds(4);
        audioSource.PlayOneShot(Music);
        john = true;
    }

    IEnumerator CameraMove()
    {
        if(john == true)
        {
            animator.SetTrigger("CameraPan");
            yield return new WaitForSeconds(3.25f);
            StartGame();
        }
        
    }
}
