using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    public State CurrentState { get; protected set; }

    public override void Setup()
    {
        base.Setup();
    }

    public override void Tick()
    {
        base.Tick();
        CurrentState.Update();
    }

    public void SetState(State state)
    {
        CurrentState?.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
