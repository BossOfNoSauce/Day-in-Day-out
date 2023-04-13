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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(john == true)
        {
            StartCoroutine(CameraMove());
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            john = true;
            
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

    IEnumerator CameraMove()
    {
        
        float step = speed * Time.deltaTime;
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, target.position, step);
        yield return new WaitForSeconds(3.25f);
        StartGame();
    }
}
