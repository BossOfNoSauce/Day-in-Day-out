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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Title());
    }

    // Update is called once per frame
    void Update()
    {
        if(john = false)
        {
            
            StartCoroutine(CameraMove());
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetBool("john", false);
            

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
        animator.SetBool("john", true);
    }

    IEnumerator CameraMove()
    {
        Debug.Log("JOHN SWEEP");
        animator.SetTrigger("CameraPan");
        yield return new WaitForSeconds(3.25f);
        StartGame();
    }
}
