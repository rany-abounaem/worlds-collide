using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageDetails
{
    public Creature Attacker { get; private set; }
    public float Damage { get; private set; }
    public DamageType DamageType { get; private set; }
    public float StaggerDuration { get; private set; } 

    public DamageDetails (Creature attacker, DamageType damageType, float damage, float staggerDuration)
    {
        Attacker = attacker;
        DamageType = damageType;
        Damage = damage;
        StaggerDuration = staggerDuration;
    }
}
