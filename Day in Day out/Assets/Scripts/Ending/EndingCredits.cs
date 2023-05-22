using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredits : MonoBehaviour
{
    public GameObject title;
    public Animator titleAnim;
    public Animator creditAnim;
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
        yield return new WaitForSeconds(6);
        creditAnim.SetTrigger("Credit");
        yield return new WaitForSeconds(46);
        SceneManager.LoadScene("MainMenu");

    }

}
