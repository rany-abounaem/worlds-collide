using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown 
{
    
    public Ability _ability;
    public float _timeRemaining;

    public Cooldown(Ability ability)
    {
        _ability = ability;
        _timeRemaining = ability.GetCooldown();
    }
}
