using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerFenetre : MonoBehaviour
{
    //Variables pour declencher les sons
    //public AudioSource openSoundWindow;
    //public AudioSource closeSoundWindow;

    //Variables animation enter et exit bird
    public GameObject birdHiver;
    public GameObject birdInside;

    //Variables private pour fermeture et ouverture de la fenetre automatique
    public HingeJoint hingeJoint;
    private float motorSpeed = 50f;
    private float motorForce = 50f;

    //Variables pour vitesse attente fermeture et ouverture de la fenetre automatique
    private float waitSecondOpen = 2f;
    private float waitSecondClose = 12f;

    //Variables pour coroutine
    Coroutine co;
    public bool cocourtine = false;
    public IEnumerator coroutine;


    void Start()
    {

        //Desactiver l'animator component de birdHiver
        birdHiver.GetComponent<Animator>().enabled = false;

        //desactiver le script QuillAnimComponent de l'enfant de birdHiver
        birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;


        //Desactiver animation fenetre
        this.GetComponent<Animator>().enabled = false;

        coroutine = StartAnimationOpen();
        cocourtine = false;

    }
    void Update()
    {
        //Si la fenetre n'est pas ouverte et que le bird n'est pas a l'interieur, ne rien faire, ne rien declancher
        if (gameObject.GetComponent<HingeJoint>().angle <= 1)
        {
            this.GetComponent<Animator>().enabled = false;
            birdHiver.GetComponent<Animator>().enabled = false;
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
            cocourtine = false;
        }//Si la fenetre commence a s'ouvrir par l'utilisateur, et que la cocoroutine est false, et que le bird n'est pas a l'interieur, lancer coroutine pour ouvrir la fenetre automatiquement
        else if (gameObject.GetComponent<HingeJoint>().angle > 10 && cocourtine == false && (birdInside.GetComponent<BirdIsInside>().birdIsInside == false || birdInside.GetComponent<BirdIsInside>().birdIsInside == true)) //&& birdIsInside == false)
        {
            StartCoroutine(coroutine);
            cocourtine = true;
        }//Si la fenetre est ouverte a 85 degres, lancer l'animation du bird et coroutine est true, lancer animation du bird qui rentre
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85 && birdInside.GetComponent<BirdIsInside>().birdIsInside == false) //&& birdIsInside == false)
        {
            birdHiver.GetComponent<Animator>().enabled = true;
            //Play l'animation du bird BirdEnterHiver
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = true;
            birdHiver.GetComponent<Animator>().Play("BirdEnterHiver");
            //Si Animator de birdHiver est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'interieur
            if (birdHiver.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75 && !birdHiver.GetComponent<Animator>().IsInTransition(0))
            {
                //activer animation fenetre qui se ferme automatiquement
                this.GetComponent<Animator>().enabled = true;
                this.GetComponent<Animator>().Play("FenetreClose");
                birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
                hingeJoint.useMotor = false;
                //stop
                cocourtine = false;

            }

        }
        //Si la fenetre est ouverte a 85 degres, lancer l'animation du bird et coroutine est true, lancer animation du bird qui sort
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85 && birdInside.GetComponent<BirdIsInside>().birdIsInside == true)
        {
            birdHiver.GetComponent<Animator>().enabled = true;
            //Play l'animation du bird BirdEnterHiver
            birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = true;
            birdHiver.GetComponent<Animator>().Play("BirdExitHiver");
            //Si Animator de birdHiver est aux 3/4 de l'animation, ferme la fenetre automatiquement, et met le bird a l'interieur
            if (birdHiver.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75 && !birdHiver.GetComponent<Animator>().IsInTransition(0))
            {
                //activer animation fenetre qui se ferme automatiquement
                this.GetComponent<Animator>().enabled = true;
                this.GetComponent<Animator>().Play("FenetreClose");
                birdHiver.GetComponentInChildren<QuillAnimComponent>().enabled = false;
                hingeJoint.useMotor = false;
                //stop
                cocourtine = false;
            }
        }


    }

    // Lancer l'animation du bird + Ouverture automatique de la fenetre
    public IEnumerator StartAnimationOpen()
    {
        yield return new WaitForSeconds(waitSecondOpen);
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





