using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : Ability
{
    [SerializeField]
    private float _energyCost;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private PlayerClass[] _allowedClasses;

    public PlayerAbility(GameObject caster): base(caster)
    {
    }

    public float GetCooldown()
    {
        return _cooldown;
    }
}
