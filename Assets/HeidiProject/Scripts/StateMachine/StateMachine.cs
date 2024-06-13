/*
    StateMachine class

    TODO: document and example

    Pierre Rossel 2019-01-24 Initial version
    Pierre Rossel 2021-04-05 Add Update()
*/

using UnityEngine;
using System.Collections;

public class StateMachine<TParent> : StateMachine<TParent, State<TParent>>
{
    public StateMachine(TParent parent) : base(parent) {}
}

public class StateMachine<TParent, TState>
{
    public class TStateBase : State<object> { }

    TParent parent;
    State<TParent> state;

    public StateMachine(TParent parent)
    {
        this.parent = parent;
    }

    public void ChangeState(State<TParent> newState)
    {
        if (state != null)
        {
            state.Exit();
        }

        newState.SetParent(parent);

        Debug.Log("StateMachine<" + typeof(TParent).Name + "> changing state to " + newState.GetType().Name);
        state = newState;

        newState.SetEnterTime(Time.time);
        newState.Enter();
    }

    public IEnumerator WaitAndChangeState(float seconds, State<TParent> nextState)
    {
        IEnumerator routine = null;
        if (parent is MonoBehaviour)
        {
            (parent as MonoBehaviour).StartCoroutine(routine = DoWaitAndChangeState(seconds, nextState));
        }
        else
        {
            Debug.LogError("WaitAndChangeState() is currently only supported with parent herited from MonoBehaviour");
        }
        return routine;
    }

    protected IEnumerator DoWaitAndChangeState(float seconds, State<TParent> nextState)
    {
        yield return new WaitForSeconds(seconds);
        ChangeState(nextState);
    }

    public TState GetState()
    {
        return (TState)(object)state;
    }

    public void Update ()
    {
        state?.Update();
    }

}
