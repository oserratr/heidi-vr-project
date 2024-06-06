using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;

public class test : MonoBehaviour
{

    //public AudioSource openSoundWindow;
    //public AudioSource closeSoundWindow;
    public GameObject animBird;


    void Start()
    {
        animBird.GetComponent<QuillAnimComponent>().enabled = false;

        // Turn off animation of bird
        animBird.GetComponent<Animator>().enabled = false;
    }

    /*void Condition()
    {
        if (gameObject.GetComponent<HingeJoint>().angle > 0)
        {
            animBird.GetComponent<Animator>().enabled = true;
            animBird.GetComponent<QuillAnimComponent>().enabled = true;
        }
        else if (gameObject.GetComponent<HingeJoint>().angle <= 0)
        {
            animBird.GetComponent<Animator>().enabled = false;
            animBird.GetComponent<QuillAnimComponent>().enabled = false;
        }
    }*/
}
