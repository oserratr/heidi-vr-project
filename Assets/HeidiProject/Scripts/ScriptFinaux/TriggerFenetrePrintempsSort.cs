using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerFenetrePrintempsSort : MonoBehaviour
{
    //Variables pour declencher les sons
    //public AudioSource openSoundWindow;
    //public AudioSource closeSoundWindow;

    //Variables animation enter et exit bird
    public GameObject birdPrintemps;
    public GameObject birdInside;
    public GameObject birdOutside;

    //Variables private pour fermeture et ouverture de la fenetre automatique
    public HingeJoint hingeJoint;
    //Variable temps
    public float delay = 6f; // Temps d'attente avant de lancer l'animation

    private float elapsedTime = 0f; // Compteur de temps

    void Start()
    {

        //Desactiver l'animator component de birdPrintemps
        //birdPrintemps.SetActive(false);
        birdPrintemps.GetComponent<Animator>().enabled = false;

        //desactiver le script QuillAnimComponent de l'enfant de birdPrintemps
        birdPrintemps.GetComponentInChildren<QuillAnimComponent>().enabled = false;


        //Desactiver animation fenetre
        this.GetComponent<Animator>().enabled = false;
        //ne pas jouer l'animation fenetre close

    }
    void Update()
    {
        //Si la fenetre n'est pas ouverte et que le bird n'est pas a l'interieur, ne rien faire, ne rien declancher
        //recupere la rotation sur l'axe x de la fenetre

        if (gameObject.GetComponent<HingeJoint>().angle <= 1)
        {
            birdPrintemps.GetComponent<Animator>().enabled = false;
            birdPrintemps.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            this.GetComponent<Animator>().enabled = false;
            //reset la position de la fenetre a celle de depart
            //print dans la console 
            Debug.Log("Fenetre fermée");


        }
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85)
        {
            birdInside.SetActive(true);
            birdPrintemps.GetComponent<Animator>().enabled = true;
            //Play l'animation du bird BirdEnterHiver
            birdPrintemps.GetComponentInChildren<QuillAnimComponent>().enabled = true;
            birdPrintemps.GetComponent<Animator>().Play("BirdExitPrintemps");
            //Si Animator de birdPrintemps est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'interieur
            FermerWindow();
            this.GetComponent<XRGrabInteractable>().enabled = false;
            //reduire opacite fenetre
            Debug.Log("Fenetre ouverte");

        }

        else if (birdInside.GetComponent<BirdIsInside>().birdIsInside == true && birdOutside.GetComponent<BirdIsOutside>().birdIsOutside == false)
        {
            birdPrintemps.GetComponent<Animator>().enabled = false;
            birdPrintemps.GetComponentInChildren<QuillAnimComponent>().enabled = false;
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
        if (birdPrintemps.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75)
        {
            //activer animation fenetre qui se ferme automatiquement
            this.GetComponent<Animator>().enabled = true;

            this.GetComponent<Animator>().Play("FenetreClose");
            birdPrintemps.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            //desactiver le script xr grab interactor
        }
    }



}





