using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredits : MonoBehaviour
{
    public GameObject title;
    public Animator titleAnim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ending());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(25);
        title.SetActive(true);
        titleAnim.SetTrigger("Title");
        //SceneManager.LoadScene("MainMenu");
        
    }

}
