using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundFenetre : MonoBehaviour
{

    public AudioSource openSoundWindow;
    public AudioSource closeSoundWindow;

    // Fonction si le joueur grab la fenetre play le son de la fenetre qui s'ouvre
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Right Hand")
        {
            openSoundWindow.Play();
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
