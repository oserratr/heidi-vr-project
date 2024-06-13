using UnityEngine;
using UnityEngine.Splines;

public class Window : MonoBehaviour
{

    public float triggerOpenAngle = 30;

    public SplineContainer splineEnter;
    public SplineContainer splineExit;

    [Tooltip("Fan number. Limit between 1 and 4")]
    [Range(1, 4)]
    public int fan = 1;

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
        UdpRelaysManager.Instance.RelayOff(fan);
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

                    // Start fan
                    UdpRelaysManager.Instance.RelayOn(fan);

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

                    // Stop fan
                    UdpRelaysManager.Instance.RelayOff(fan);

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
