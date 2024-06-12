using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuillAnimation : MonoBehaviour
{
    public int frameRate = 12;
    public int frame = 0;
    public GameObject animationRoot;

    public int triggerFrame;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //desactiver l'enfant du current frame et activer l'enfant du prochain frame
        animationRoot.transform.GetChild(frame).gameObject.SetActive(false);

        //incrementer frame selon le nombre d'enfant dans animationRoot
        frame = (frame + 1) % animationRoot.transform.childCount;
        //activer l'enfant du prochain frame
        animationRoot.transform.GetChild(frame).gameObject.SetActive(true);

        //ne pas loop l'animation
        if (frame == triggerFrame)
        {
            enabled = false;
        }
    }
}
