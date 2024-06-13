using UnityEngine;
using UnityEngine.Splines;

public class Bird : MonoBehaviour
{
    public static Bird instance;

    SplineAnimate splineAnimate;

    StateMachine<Bird, StateBird> sm;

    Window activeWindow;

    class StateBird : State<Bird>
    {
        public virtual void OnSplineAnimationCompleted()
        { }

        public virtual void OnWindowOpened(Window window)
        {
            Debug.Log("Bird is somewhere and window opened");
            window.Close();
        }

        public virtual void OnWindowClosed(Window window)
        { }
    }

    class StateInside : StateBird
    {
        public override void OnWindowOpened(Window window)
        {
            Debug.Log("Bird is inside and window opened");

            // Set active window
            parent.activeWindow = window;

            // Start animation
            parent.splineAnimate.Container = window.splineExit;
            parent.splineAnimate.Restart(true);

            parent.sm.ChangeState(new StateExiting());
        }

    }

    class StateOutside : StateBird
    {
        public override void OnWindowOpened(Window window)
        {
            Debug.Log("Bird is outside and window opened");

            // Set active window
            parent.activeWindow = window;

            // Start animation
            parent.splineAnimate.Container = window.splineEnter;
            parent.splineAnimate.Restart(true);

            parent.sm.ChangeState(new StateEntering());
        }
    }

    class StateEntering : StateBird
    {
        public override void OnSplineAnimationCompleted()
        {
            Debug.Log("Bird has entered the room");
            parent.sm.ChangeState(new StateInside());

            // close the window
            parent.activeWindow.Close();
        }

    }

    class StateExiting : StateBird
    {
        public override void OnSplineAnimationCompleted()
        {
            Debug.Log("Bird has exited the room");
            parent.sm.ChangeState(new StateOutside());

            // close the window
            parent.activeWindow.Close();
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        splineAnimate = GetComponent<SplineAnimate>();

        // Subscribe to the Completed event
        splineAnimate.Completed += OnSplineAnimationCompleted;

        sm = new StateMachine<Bird, StateBird>(this);
        sm.ChangeState(new StateOutside());

    }

    // Update is called once per frame
    void Update()
    {
        sm.Update();
    }

    void OnSplineAnimationCompleted()
    {
        Debug.Log("Spline animation completed!");
        sm.GetState().OnSplineAnimationCompleted();
    }

    public void OnWindowOpened(Window window)
    {
        Debug.Log("Window opened!");

        sm.GetState().OnWindowOpened(window);
    }

    public void OnWindowClosed(Window window)
    {
        Debug.Log("Window closed!");
        sm.GetState().OnWindowClosed(window);
    }
}
