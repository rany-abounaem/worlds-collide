using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DeathCallback();

public abstract class Enemy : Creature
{
    public LootComponent Loot { get; private set; }

    [SerializeField]
    private float _experienceDrop;
    [SerializeField]
    private float AggroRange;
    [SerializeField]
    private HealthUI _healthUI;

    [SerializeField]
    private DetectionArea _detectionArea;

    public event DeathCallback OnDeath;
    public Creature Target { get; set; }
    public State CurrentState { get; protected set; }

    public override void Setup()
    {
        base.Setup();
        Loot = GetComponent<LootComponent>();
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

    public float GetExperienceDrop()
    {
        return _experienceDrop;
    }

    public override void TakeDamage(DamageDetails damageDetails)
    {
        base.TakeDamage(damageDetails);
        if (Stats.GetHealth() == 0)
        {
            OnDeath?.Invoke();
        }
    }
}
