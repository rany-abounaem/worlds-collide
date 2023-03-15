using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IDamageable
{
    public MovementComponent Movement { get; private set; }
    public AbilityComponent Ability { get; private set; }

    virtual public StatsComponent Stats { get; private set; }

    virtual public void Setup()
    {
        Movement = GetComponent<MovementComponent>();
        Ability = GetComponent<AbilityComponent>();
        Stats = GetComponent<StatsComponent>();
    }

}
