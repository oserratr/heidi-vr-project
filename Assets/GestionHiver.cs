using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionHiver : MonoBehaviour
{
    public GameObject sort;
    public GameObject rentre;
    public GameObject birdInside;
    // Start is called before the first frame update
    void Start()
    {
        sort.SetActive(false);
        rentre.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // si le bird est a l'interieur
        if (birdInside.GetComponent<BirdIsInside>().birdIsInside == true)

        {
            sort.SetActive(true);
            rentre.SetActive(false);
        }
        else if (birdInside.GetComponent<BirdIsOutside>().birdIsOutside == false)
        {
            sort.SetActive(false);
            rentre.SetActive(true);
        }
    }
}
