using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredits : MonoBehaviour
{
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
        SceneManager.LoadScene("MainMenu");
    }

}
