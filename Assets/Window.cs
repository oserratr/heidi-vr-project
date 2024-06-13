using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

    // Window States
    public enum WindowState
    {
        Open,
        Closed,
        Closing
    }

    public WindowState state = WindowState.Closed;

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
                if (hinge.angle > 80)
                {
                    state = WindowState.Open;
                    
                    JointSpring hingeSpring = hinge.spring;
                    hingeSpring.targetPosition = 90;
                    hinge.spring = hingeSpring;
                }

                break;
            case WindowState.Closing:
                // Debug.Log("Window is closing");
                break;
        }
    }

    
}
