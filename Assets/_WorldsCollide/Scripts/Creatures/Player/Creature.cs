using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HitCallback(DamageDetails damageDetails);

public abstract class Creature : MonoBehaviour, IDamageable
{
    public Rigidbody2D Rigidbody { get; private set; }
    public MovementComponent Movement { get; private set; }
    public AbilityComponent Ability { get; private set; }
    public Animator Anim { get; private set; }
    virtual public StatsComponent Stats { get; private set; }

    public event HitCallback OnTakeDamage;

    public FloatingTextRaiser FloatingText { get; private set; }

    [ContextMenu("Setup")]
    public virtual void Setup()
    {
        Anim = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Movement = GetComponent<MovementComponent>();
        Movement.Setup(Anim, Rigidbody);
        Ability = GetComponent<AbilityComponent>();
        Ability.Setup(this);
        Stats = GetComponent<StatsComponent>();
        FloatingText = GetComponent<FloatingTextRaiser>();
    }

    public virtual void Tick()
    {

    }

    public virtual void TakeDamage(DamageDetails damageDetails)
    {
        var __damage = damageDetails.Damage;
        Stats.ReduceHealth(__damage);
        OnTakeDamage?.Invoke(damageDetails);
        Instantiate(GameplaySystem.instance.BloodEffect, transform.position, Quaternion.identity, transform);
        FloatingText.SpawnFloatingText(transform.position, __damage.ToString(), Color.red);
    }

}
