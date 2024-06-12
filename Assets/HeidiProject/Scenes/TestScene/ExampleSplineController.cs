using System.Threading;
using UnityEngine;
using UnityEngine.Splines;


public class ExampleSplineController : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public SplineContainer EteIn;
    public SplineContainer EteOut;
    public SplineContainer AutomnIn;
    public SplineContainer AutomnOut;
    public SplineContainer HiverIn;
    public SplineContainer HiverOut;
    public SplineContainer PrintempsIn;
    public SplineContainer PrintempsOut;
    int Count = 0;

    void Start()
    {
        // Ensure PlayOnAwake is disabled
        splineAnimate.PlayOnAwake = false;

        // Optionally, restart the animation to ensure it starts from the beginning without autoplaying
        splineAnimate.Restart(false);

        // Subscribe to the Completed event
        splineAnimate.Completed += OnSplineAnimationCompleted;

        
        splineAnimate.Play(); // Play the animation

    }

    void Update()
    {
        //splineAnimate.Play(); 
        //splineAnimate.Pause();
        //splineAnimate.Restart(true); // Restart and autoplay

    }
    // if (splineAnimate.IsPlaying = true){}

    void OnSplineAnimationCompleted()
    {
        
        Count ++;
        if (Count == 1)
        {
            
            splineAnimate.ChangeSpline(EteOut);
            splineAnimate.Restart(true);
            
        }
        else if (Count == 2)
        {
            splineAnimate.ChangeSpline(AutomnIn);
            splineAnimate.Restart(true);
            
        }
        else if (Count == 3)
        {   
            splineAnimate.ChangeSpline(AutomnOut);
            
            
            splineAnimate.Restart(true);
        }
        else if (Count == 4)
        {   
            
            splineAnimate.Restart(false);
        }
        
        // Start the animation after a short delay
    
    }

 

    void OnDestroy()
    {
        // Unsubscribe from the Completed event to avoid memory leaks
        splineAnimate.Completed -= OnSplineAnimationCompleted;
    }
}
