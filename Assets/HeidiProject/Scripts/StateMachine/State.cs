/*
	State to be used with StateMachine class.

	To be used as is or as base class to define your own state class with specific data and methods.

	TODO: document and example

	Pierre Rossel 2019-01-24 Initial version
    Pierre Rossel 2021-04-05 Add Update()
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T>
{
    protected T parent;

    private float enterTime;

    public void SetParent(T parent)
    {
        this.parent = parent;
    }


    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }


    public void SetEnterTime(float enterTime)
    {
        this.enterTime = enterTime;
    }

    public float GetStateTime()
    {
        return Time.time - enterTime;
    }
}
