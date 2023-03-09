using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    List<Cooldown> _cooldowns = new List<Cooldown>();

    public void AddCooldown(Ability ability)
    {
        _cooldowns.Add(new Cooldown(ability));
    }

    public float AbilityOnCooldown(Ability ability)
    {
        foreach (var __cooldown in _cooldowns)
        {
            if(__cooldown._ability == ability)
            {
                return __cooldown._timeRemaining;
            }
        }
        return -1f;
    }

    private void Update()
    {
        foreach (var __cooldown in _cooldowns)
        {
            __cooldown._timeRemaining -= Time.deltaTime;
            if (__cooldown._timeRemaining <= 0)
            {
                _cooldowns.Remove(__cooldown);
            }
        }
    }
}
