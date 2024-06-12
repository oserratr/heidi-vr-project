using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRotationZ : MonoBehaviour
{
    void Update()
    {
        // Récupérer la rotation en angles d'Euler locaux
        float rotationZ = transform.localEulerAngles.z;

        // Afficher la valeur dans la console
        Debug.Log("Rotation sur l'axe Z : " + rotationZ + " degrés");
    }
}
