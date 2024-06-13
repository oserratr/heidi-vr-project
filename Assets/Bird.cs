using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Bird : MonoBehaviour
{
    SplineAnimate splineAnimate;

    // Start is called before the first frame update
    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();

                // Subscribe to the Completed event
        splineAnimate.Completed += OnSplineAnimationCompleted;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSplineAnimationCompleted()
    {
        Debug.Log("Spline animation completed!");
    }
}
