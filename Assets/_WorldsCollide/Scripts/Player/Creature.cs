using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IDamageable
{
    public Rigidbody2D Rigidbody { get; private set; }
    public MovementComponent Movement { get; private set; }
    public AbilityComponent Ability { get; private set; }
    public Animator Animator { get; private set; }

    virtual public StatsComponent Stats { get; private set; }

    virtual public void Setup()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Movement = GetComponent<MovementComponent>();
        Movement.Setup(Animator, Rigidbody);
        Ability = GetComponent<AbilityComponent>();
        Ability.Setup(this);
        Stats = GetComponent<StatsComponent>();
        
    }

}
