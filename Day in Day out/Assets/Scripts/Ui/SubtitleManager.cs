using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour
{
    public GameObject textBox;
    public LittleBookScript bookScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //done
    public IEnumerator intro()
    {
       
         yield return new WaitForSeconds(4.5f);
         textBox.GetComponent<Text>().text = "Hey... *uh* Bad news mate ";
         yield return new WaitForSeconds(2);
         textBox.GetComponent<Text>().text = "so *like* Apparently our stocks have gone down";
         yield return new WaitForSeconds(2.5f);
         textBox.GetComponent<Text>().text = "like, way, way down";
         yield return new WaitForSeconds(2.8f);
         textBox.GetComponent<Text>().text = "and it's supposedly because everyone hasn't been doing *like*";
         yield return new WaitForSeconds(3);
         textBox.GetComponent<Text>().text = "ANYTHING";
         yield return new WaitForSeconds(2);
         textBox.GetComponent<Text>().text = "so now the boss is pretty *uh* peeved off and has made some harsh polices to";
         yield return new WaitForSeconds(5.8f);
         textBox.GetComponent<Text>().text = "y'know *uh* weed out the slackers";
         yield return new WaitForSeconds(3.5f);
         textBox.GetComponent<Text>().text = "so now everyone has to complete a consistent percentage of work and turn it into the boss at the end of the day";
         yield return new WaitForSeconds(5.5f);
         textBox.GetComponent<Text>().text = "pretty inconvenient if you ask me ";
         yield return new WaitForSeconds(1.5f);
         textBox.GetComponent<Text>().text = "I would file a complaint but I *uh* REALLY don't wanna get on the big guy's bad side ";
         yield return new WaitForSeconds(5.5f);
         textBox.GetComponent<Text>().text = "Here... ";
         yield return new WaitForSeconds(1.5f);
         bookScript.startSlide = true;
         yield return new WaitForSeconds(2f);
         textBox.GetComponent<Text>().text = "Just *uh* write your junk in that and turn it in at the end of the day ";
         yield return new WaitForSeconds(4);
         textBox.GetComponent<Text>().text = "Just trying to make sure you don't get in trouble, I'll let you get back to your... *uh* ";
         yield return new WaitForSeconds(5);
         textBox.GetComponent<Text>().text = "whatever you're doing... ";
         yield return new WaitForSeconds(2);
         textBox.GetComponent<Text>().text = " ";
         yield return new WaitForSeconds(1); 
    }


    //done
    public IEnumerator Boss1()
    {
        yield return new WaitForSeconds(0.7f);
        textBox.GetComponent<Text>().text = "Well, well, well, look who we got here";
        yield return new WaitForSeconds(2.7f);
        textBox.GetComponent<Text>().text = "Good to see you kid";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "Outta everyone is this office, you was the one I was the least worried about";
        yield return new WaitForSeconds(4.3f);
        textBox.GetComponent<Text>().text = "Don't worry about turnin' in your book";
        yield return new WaitForSeconds(2.3f);
        textBox.GetComponent<Text>().text = "I trust ya enough that you're not gonna toss it or burn it or somethin'";
        yield return new WaitForSeconds(3.8f);
        textBox.GetComponent<Text>().text = "I must say, I apologize for pushing these new rules on ya kid";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "But our business, is frankly in disarray";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "This establishment is full of";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "LAZY";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "GOOD FOR NOTHING";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "FREELOADERS";
        yield return new WaitForSeconds(1.5F);
        textBox.GetComponent<Text>().text = "I gotta do what I gotta do, for the greater good of this company";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "So, keep up the good work, and don't dissappoint me";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = " ";
    }

    //done
    public IEnumerator Boss2()
    {
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Well, if it isnt my number one employee";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "I see you got your work completed as soon as possible";
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<Text>().text = "I’ll let you out a tad early cause I’m in a good mood, and you know what";
        yield return new WaitForSeconds(4.5f);
        textBox.GetComponent<Text>().text = "I’ll give you a raise";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "Ya know, some here just don’t get it…";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "You’re the perfect example of the working man";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "and yet even you can’t inspire these lousy loafers";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "around the building to actually";
        yield return new WaitForSeconds(1.4f);
        textBox.GetComponent<Text>().text = "achieve something with their pathetic existence";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Someday, they’ll learn...";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "or else I’ll just have to teach ‘em the hard way";
        yield return new WaitForSeconds(3.25f);
        textBox.GetComponent<Text>().text = "Anyway, go on and enjoy the rest of the day kid";
        yield return new WaitForSeconds(2.75f);
        textBox.GetComponent<Text>().text = "enjoy the two cent raise";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = " ";
    }

    //done
    public IEnumerator Boss3()
    {
        yield return new WaitForSeconds(0.3f);
        textBox.GetComponent<Text>().text = "Ah , there's the big shot";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "Another day well done kid";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "You're the good example of a worker ant";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Actually gets the job done, nothing more, nothing less";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "If I could make every employee like you";
        yield return new WaitForSeconds(1.8f);
        textBox.GetComponent<Text>().text = "I could stop taking my heart medication!";
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<Text>().text = " (hearty wheezy awkward laugh)";
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<Text>().text = "Ahh anyways, go home kid";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "enjoy the rest of the day";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "while i sort out these *other* employees";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = " ";
    }

    //done
    public IEnumerator Boss4()
    {
        yield return new WaitForSeconds(0.3f);
        textBox.GetComponent<Text>().text = "Uh.. he-hey, there ya are kid";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "Ah... Another stellar day of work, as always";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "I would give you another raise";
        yield return new WaitForSeconds(1.7f);
        textBox.GetComponent<Text>().text = "but projects are coming up that need my financing";
        yield return new WaitForSeconds(3.2f);
        textBox.GetComponent<Text>().text = "N-not to say that you're not doing great";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = "but there's just others things on my plate";
        yield return new WaitForSeconds(2f);
        textBox.GetComponent<Text>().text = "Hell, one of these days";
        yield return new WaitForSeconds(1.4f);
        textBox.GetComponent<Text>().text = "you should take a vacation";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Anyway, go home kid, move on";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = " ";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Go";
        yield return new WaitForSeconds(1f);
        textBox.GetComponent<Text>().text = " ";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "C'mon git";
        yield return new WaitForSeconds(1f);
        textBox.GetComponent<Text>().text = " ";
        yield return new WaitForSeconds(1.2f);
        textBox.GetComponent<Text>().text = "Scram";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = " ";
    }

    

    public IEnumerator Boss5()
    {
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "Hey uh kid, whatcha doin here.";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "You don’t need to be here today ";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "I’m uh a little busy with something…  ";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<Text>().text = "Huh? You wondering where everyone is? ";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "Well…";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = "It’s national be lazy and don’t come to work day…";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "yeah…";
        yield return new WaitForSeconds(1.4f);
        textBox.GetComponent<Text>().text = "So uh... go home...";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = " ";
    }

    public IEnumerator BossEnd()
    {
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "I told you I’m busy, kid…";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "You’re supposed to do exactly what I say,";
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "but no. You just ahd to disobey me...";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<Text>().text = "You’re just like the rest of those incompetent slackers.";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "Never listening till it’s too late.";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = "This company will skyrocket now that all those";
        yield return new WaitForSeconds(3.5f);
        textBox.GetComponent<Text>().text = "worthless employees are now top of the line machines.";
        yield return new WaitForSeconds(1.4f);
        textBox.GetComponent<Text>().text = "Finally listening to my commands and doing it,";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "rather than wasting every single day ";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "slowly withing this company to death!";
        yield return new WaitForSeconds(3.25f);
        textBox.GetComponent<Text>().text = "I gave you a chance to leave, kid,";
        yield return new WaitForSeconds(2.75f);
        textBox.GetComponent<Text>().text = "but now you’ve seen too much…";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = "YOU'RE FIRED";
        yield return new WaitForSeconds(2.25f);
        textBox.GetComponent<Text>().text = " ";
    }
}
