using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject, ISlottable
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
    [SerializeField]
    protected Sprite _icon;

    protected Creature _caster;
    protected Animator _animator;
    virtual public void Setup(Creature creature)
    {
        _caster = creature;
        _animator = _caster.Anim;
    }

    virtual public void Use()
    {
        
    }

    virtual public void HandleSequence (int sequence)
    {

    }

    public string GetName()
    {
        return _name;
    }

    public float GetCooldown()
    {
        return _cooldown;
    }

    public Sprite GetSprite()
    {
        return _icon;
    }
}
