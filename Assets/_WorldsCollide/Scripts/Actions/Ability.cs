using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _energyCost;
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    public GameObject Caster { get ; private set; }

    public Ability(GameObject caster)
    {
        Caster = caster;
    }

    public float GetCooldown()
    {
        return _cooldown;
    }

    virtual public void Use()
    {
        Debug.Log("Used action");
    }
}
