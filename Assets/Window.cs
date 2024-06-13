using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Window : MonoBehaviour
{

    public float triggerOpenAngle = 30;

    public SplineContainer splineEnter;
    public SplineContainer splineExit;

    // Window States
    public enum WindowState
    {
        Open,
        Closed,
        Closing
    }

    WindowState state = WindowState.Closed;

    HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case WindowState.Open:
                // Debug.Log("Window is open");
                break;

            case WindowState.Closed:
                // Debug.Log("Window is closed");
                // if angle > 80 degrees change state to open
                if (hinge.angle > triggerOpenAngle)
                {
                    // Change state
                    state = WindowState.Open;

                    // Finish opening the windows
                    JointSpring hingeSpring = hinge.spring;
                    hingeSpring.targetPosition = 90;
                    hinge.spring = hingeSpring;

                    // Notfy the bird
                    Bird.instance.OnWindowOpened(this);
                }

                break;

            case WindowState.Closing:
                // Debug.Log("Window is closing");

                // if angle < 10 degrees change state to closed
                if (hinge.angle < 1)
                {
                    // Change state
                    state = WindowState.Closed;

                    // Notify the bird
                    Bird.instance.OnWindowClosed(this);
                }

                break;
        }
    }

    public void Close()
    {
        // Change state
        state = WindowState.Closing;

        // Close the window
        JointSpring hingeSpring = hinge.spring;
        hingeSpring.targetPosition = 0;
        hinge.spring = hingeSpring;
    }
}
