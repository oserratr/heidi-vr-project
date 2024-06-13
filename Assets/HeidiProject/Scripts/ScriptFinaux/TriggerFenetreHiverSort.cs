using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerFenetreHiverSort : MonoBehaviour
{
    //Variables pour declencher les sons
    //public AudioSource openSoundWindow;
    //public AudioSource closeSoundWindow;

    //Variables animation enter et exit bird
    public GameObject birdHiver;
    public GameObject birdInside;
    public GameObject birdOutside;

    //Variables private pour fermeture et ouverture de la fenetre automatique
    public new HingeJoint hingeJoint;
    //Variable temps
    public float delay = 6f; // Temps d'attente avant de lancer l'animation

    private float elapsedTime = 0f; // Compteur de temps

    void Start()
    {

        //Desactiver l'animator component de birdHiver
        birdHiver.GetComponent<Animator>().enabled = false;

        //desactiver le script QuillAnimComponent de l'enfant de birdHiver
        birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;


        //Desactiver animation fenetre
        this.GetComponent<Animator>().enabled = false;
        //ne pas jouer l'animation fenetre close

    }
    void Update()
    {
        //Si la fenetre n'est pas ouverte et que le bird n'est pas a l'interieur, ne rien faire, ne rien declancher
        //recupere la rotation sur l'axe x de la fenetre

        if (gameObject.GetComponent<HingeJoint>().angle <= 1 && birdInside.GetComponent<BirdIsInside>().birdIsInside == false && birdOutside.GetComponent<BirdIsOutside>().birdIsOutside == true)
        {
            birdHiver.GetComponent<Animator>().enabled = false;
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
            //reset la position de la fenetre a celle de depart


        }
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85)
        {
            birdHiver.GetComponent<Animator>().enabled = true;
            //Play l'animation du bird BirdEnterHiver
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = true;
            birdHiver.GetComponent<Animator>().Play("BirdExitHiver");
            //Si Animator de birdHiver est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'interieur
            FermerWindow();
            this.GetComponent<XRGrabInteractable>().enabled = false;
            //reduire opacite fenetre

        }

        else if (birdInside.GetComponent<BirdIsInside>().birdIsInside == true && birdOutside.GetComponent<BirdIsOutside>().birdIsOutside == false)
        {
            birdHiver.GetComponent<Animator>().enabled = false;
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            //reset la position de la fenetre a celle de depart
            elapsedTime += Time.deltaTime; // Incrémenter le compteur de temps

            if (elapsedTime >= delay)
            {
                this.GetComponent<Animator>().enabled = false;
                elapsedTime = 0;
            }


        }


    }
    public void FermerWindow()
    {
        if (birdHiver.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75)
        {
            //activer animation fenetre qui se ferme automatiquement
            this.GetComponent<Animator>().enabled = true;

            this.GetComponent<Animator>().Play("FenetreClose");
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            //desactiver le script xr grab interactor
        }
    }



}





