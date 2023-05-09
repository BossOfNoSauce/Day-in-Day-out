using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationTrigger : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            //do thing
            SceneManager.LoadScene("Ending");
        }

    }
}
