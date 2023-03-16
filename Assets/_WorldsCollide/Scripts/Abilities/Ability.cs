using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [SerializeField]
    private AnimationClip _animation;
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _energyCost;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private PlayerClass[] _allowedClasses;
    [SerializeField]
    public GameObject Caster { get ; private set; }

    public Ability(GameObject caster)
    {
        Caster = caster;
    }

    virtual public void Use()
    {
        Debug.Log("Used action");
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
