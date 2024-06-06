using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuillAnim;

public class TriggerFenetre : MonoBehaviour
{

    public AudioSource openSoundWindow;
    public AudioSource closeSoundWindow;
    public GameObject animBird;
    // declarer un variable pour que le HingeJoint de ce gameobject soit aussi en mode edit
    public HingeJoint hingeJoint;
    //public float targetAngle;
    private float motorSpeed = 50f;
    private float motorForce = 50f;

    private float waitSecondOpen = 2f;





    void Start()
    {

        // attendre 1 miliseconde avant de metre a false le component QuillAnimComponent
        animBird.GetComponent<QuillAnimComponent>().enabled = true;
        // Turn off animation of bird
        animBird.GetComponent<Animator>().enabled = false;
    }
    void Update()
    {

        if (gameObject.GetComponent<HingeJoint>().angle <= 1)
        {
            animBird.GetComponent<Animator>().enabled = false;
            animBird.GetComponent<QuillAnimComponent>().enabled = false;
        }
        else if (gameObject.GetComponent<HingeJoint>().angle > 10)
        {
            // Apres 2 second lancer l'animation du bird
            StartCoroutine(StartAnimationOpen());
        }

    }

    // Lancer l'animation du bird + Ouverture automatique de la fenetre
    IEnumerator StartAnimationOpen()
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
        //declarer une variable float targetAngle
        float targetAngle = 90;
        float currentAngle = hingeJoint.angle;
        float angleDifference = targetAngle - currentAngle;

        // Définir la vitesse du moteur en fonction de la différence d'angle
        motor.targetVelocity = angleDifference > 0 ? motorSpeed : -motorSpeed;
        /*hingeJoint.motor = motor;*/
        // Active animation du bird
        animBird.GetComponent<QuillAnimComponent>().enabled = true;
        animBird.GetComponent<Animator>().enabled = true;
    }



}
