using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerFenetreEte : MonoBehaviour
{
    //Variables pour declencher les sons
    //public AudioSource openSoundWindow;
    //public AudioSource closeSoundWindow;

    //Variables animation enter et exit bird
    public GameObject birdEnter;
    public GameObject frameBirdEnter;
    public GameObject birdExit;
    public bool birdIsInside = false;

    //Variables private pour fermeture et ouverture de la fenetre automatique
    public new HingeJoint hingeJoint;
    private float motorSpeed = 50f;
    private float motorForce = 50f;

    //Variables pour vitesse attente fermeture et ouverture de la fenetre automatique
    private float waitSecondOpen = 2f;
    // private float waitSecondClose = 12f;

    //Variables pour coroutine
    Coroutine co;
    bool cocourtine = false;

    //Gameobject pour les fenetres saisons
    public GameObject printempsFenetre;
    public GameObject hiverFenetre;
    public GameObject automneFenetre;




    void Start()
    {
        //Activer le GameObject frameBirdEnter
        frameBirdEnter.SetActive(true);

        //Desactiver le GameObject animBirdEnter
        birdEnter.SetActive(false);

        //Desactiver le GameObject birdExit
        birdExit.SetActive(false);

        //Desactiver animation fenetre
        this.GetComponent<Animator>().enabled = false;

    }
    void Update()
    {
        //Si la fenetre n'est pas ouverte et que le bird n'est pas a l'interieur, ne rien faire, ne rien declancher
        if (gameObject.GetComponent<HingeJoint>().angle <= 1 && birdIsInside == false && hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == false && automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == false && printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == false)
        {
            //Activer le GameObject frameBirdEnter
            frameBirdEnter.SetActive(true);

            //Desactiver le GameObject animBirdEnter
            birdEnter.SetActive(false);
        }//Si la fenetre commence a s'ouvrir par l'utilisateur, et que la cocoroutine est false, et que le bird n'est pas a l'interieur, lancer coroutine pour ouvrir la fenetre automatiquement
        else if (gameObject.GetComponent<HingeJoint>().angle > 10 && cocourtine == false && birdIsInside == false && hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == false && automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == false && printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == false)
        {
            // Apres 2 second lancer l'animation du bird
            co = StartCoroutine(StartAnimationOpen());
            cocourtine = true;
        }//Si la fenetre est ouverte a 85 degres, lancer l'animation du bird et coroutine est true, lancer animation du bird qui rentre
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85 && cocourtine == true && birdIsInside == false && hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == false && automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == false && printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == false)
        {
            birdEnter.SetActive(true);
            frameBirdEnter.SetActive(false);
            birdEnter.GetComponent<Animator>().enabled = true;

            //Si Animator de birdEnter est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'interieur
            if (birdEnter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95 && !birdEnter.GetComponent<Animator>().IsInTransition(0))
            {
                this.GetComponent<Animator>().enabled = true;
                hingeJoint.useMotor = false;
                //stop
                StopCoroutine(co);
                cocourtine = false;
                birdIsInside = true;
            }


        }//Si la fenetre commence a s'ouvrir par l'utilisateur, et que la cocoroutine est false, et que le bird est a l'interieur, lancer coroutine pour ouvrir la fenetre automatiquement
        else if (gameObject.GetComponent<HingeJoint>().angle > 10 && cocourtine == false && (hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == true || automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == true || printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == true))
        {
            // Apres 2 second lancer l'animation du bird
            co = StartCoroutine(StartAnimationOpen());
            cocourtine = true;
        }// Si la fenetre n'est pas ouverte mais qu'il y a un bird inside alors arrhiverr l'animation de la fermeture automatique de la fenetre et activer le scirpt XR Grab Interactable
        else if (gameObject.GetComponent<HingeJoint>().angle <= 1 && (hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == true || automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == true || printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == true))
        {
            this.GetComponent<XRGrabInteractable>().enabled = true;
            this.GetComponent<Animator>().enabled = false;
        }//Si la fenetre est ouverte a 85 degres, lancer l'animation du bird et coroutine est true, lancer animation du bird qui sort
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85 && cocourtine == true && (hiverFenetre.GetComponent<TriggerFenetreHiver>().birdIsInside == true || automneFenetre.GetComponent<TriggerFenetreAutomne>().birdIsInside == true || printempsFenetre.GetComponent<TriggerFenetrePrintemps>().birdIsInside == true))
        {
            birdExit.SetActive(true);
            birdEnter.SetActive(false);
            birdExit.GetComponent<Animator>().enabled = true;

            //Si Animator de birdEnter est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'exiterieur
            if (birdExit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95 && !birdExit.GetComponent<Animator>().IsInTransition(0))
            {
                this.GetComponent<Animator>().enabled = true;
                hingeJoint.useMotor = false;
                //stop
                StopCoroutine(co);
                cocourtine = false;
                birdIsInside = false;
            }
        }



    }

    // Lancer l'animation du bird + Ouverture automatique de la fenetre
    IEnumerator StartAnimationOpen()
    {
        yield return new WaitForSeconds(waitSecondOpen);
        this.GetComponent<XRGrabInteractable>().enabled = false;

        // desactiver le script de ce gameobject XR Grab Interactable
        if (hingeJoint == null)
        {
            hingeJoint = GetComponent<HingeJoint>();
        }

        // Configurer le moteur
        JointMotor motor = hingeJoint.motor;
        motor.force = motorForce;
        motor.targetVelocity = motorSpeed;
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;
        //declarer une variable float targetAngleOpen
        float targetAngle = 90;
        float currentAngle = hingeJoint.angle;
        float angleDifference = targetAngle - currentAngle;

        // Définir la vitesse du moteur en fonction de la différence d'angle
        motor.targetVelocity = angleDifference > 0 ? motorSpeed : -motorSpeed;

    }

}





