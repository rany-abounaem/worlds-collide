using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected float _range;
    [SerializeField]
    protected float _energyCost;
    [SerializeField]
    protected float _cooldown;
    [SerializeField]
    protected PlayerClass[] _allowedClasses;

    protected Creature _caster;
    protected Animator _animator;
    virtual public void Setup(Creature creature)
    {
        _caster = creature;
        _animator = _caster.Animator;
    }

    virtual public void Use()
    {
        
    }

    virtual public void HandleSequence (int sequence)
    {

    }

    public string GetAbilityName()
    {
        return _name;
    }

    public float GetCooldown()
    {
        return _cooldown;
    }
}
