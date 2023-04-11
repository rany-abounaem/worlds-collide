using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    [SerializeField]
    private float AggroRange;
    [SerializeField]
    private HealthUI _healthUI;

    [SerializeField]
    private DetectionArea _detectionArea;

    public Creature Target { get; set; }
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

    public DetectionArea GetDetectionArea()
    {
        return _detectionArea;
    }

    public float GetAggroRange()
    {
        return AggroRange;
    }
}
