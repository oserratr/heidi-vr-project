using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerFenetre : MonoBehaviour
{
    //Variables pour declencher les sons
    public AudioSource openSoundWindow;
    public AudioSource closeSoundWindow;

    //Variables animation enter et exit bird
    public GameObject animBird;


    //Variables private pour fermeture et ouverture de la fenetre automatique
    public HingeJoint hingeJoint;
    private float motorSpeed = 50f;
    private float motorForce = 50f;

    //Variables pour vitesse attente fermeture et ouverture de la fenetre automatique
    private float waitSecondOpen = 2f;
    private float waitSecondClose = 12f;

    //Variables pour coroutine
    Coroutine co;
    bool cocourtine = false;

    //Gameobject pour les fenetres saisons
    public GameObject printempsFenetre;
    public GameObject eteFenetre;
    public GameObject automneFenetre;




    void Start()
    {

        // attendre 1 miliseconde avant de metre a false le component QuillAnimComponent
        animBird.GetComponent<QuillAnimComponent>().enabled = true;
        // Turn off animation of bird
        animBird.GetComponent<Animator>().enabled = false;
        this.GetComponent<Animator>().enabled = false;

    }
    void Update()
    {

        if (gameObject.GetComponent<HingeJoint>().angle <= 1)
        {
            animBird.GetComponent<Animator>().enabled = false;
            animBird.GetComponent<QuillAnimComponent>().enabled = false;
        }
        else if (gameObject.GetComponent<HingeJoint>().angle > 10 && cocourtine == false)
        {
            // Apres 2 second lancer l'animation du bird
            co = StartCoroutine(StartAnimationOpen());
            cocourtine = true;
        }
        else if (gameObject.GetComponent<HingeJoint>().angle >= 85)
        {
            animBird.GetComponent<QuillAnimComponent>().enabled = true;
            animBird.GetComponent<Animator>().enabled = true;
            //si Animator de animBird est aux 3/4 de l'animation start l'animation de cet gameobject
            if (animBird.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.75 && !animBird.GetComponent<Animator>().IsInTransition(0))
            {
                this.GetComponent<Animator>().enabled = true;
                hingeJoint.useMotor = false;
                //this.GetComponent<XRGrabInteractable>().enabled = true;
                //this.GetComponent<Animator>().enabled = false;

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





