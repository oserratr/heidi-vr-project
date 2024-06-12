using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdIsOutside : MonoBehaviour
{
    public bool birdIsOutside = false;


    //Si ce gameObject est en collision, mettre birdIsOutside a true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bird")
        {
            birdIsOutside = true;
        }
    }

    //Si ce gameObject n'est plus en collision, mettre birdIsOutside a false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bird")
        {
            birdIsOutside = false;
        }
    }
}
