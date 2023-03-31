using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    [SerializeField]
    HealthUI _healthUI;

    [SerializeField]
    DetectionArea _detectionArea;

    public State CurrentState { get; protected set; }

    public override void Setup()
    {
        base.Setup();
        _healthUI.Setup(this);
    }

    public override void Tick()
    {
        base.Tick();
        CurrentState.Update();
    }

    public void SetState(State state)
    {
        CurrentState?.Exit();
        state.Enter();
        CurrentState = state;
    }
}
