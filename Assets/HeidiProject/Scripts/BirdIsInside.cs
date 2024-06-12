using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIsInside : MonoBehaviour
{
    public bool birdIsInside = false;


    //Si ce gameObject est en collision, mettre birdIsInside a true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bird")
        {
            birdIsInside = true;
        }
    }

    //Si ce gameObject n'est plus en collision, mettre birdIsInside a false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bird")
        {
            birdIsInside = false;
        }
    }
}
