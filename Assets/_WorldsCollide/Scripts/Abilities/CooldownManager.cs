using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager
{
    Dictionary<string, float> _cooldowns = new Dictionary<string, float>();

    public void AddCooldown(string name, float cooldown)
    {
        Debug.Log("Added ability");
        _cooldowns.Add(name, cooldown);
    }

    public float AbilityOnCooldown(string name)
    {
        if (_cooldowns.ContainsKey(name))
        {
            return _cooldowns[name];
        }
        return -1f;
    }

    public void Tick()
    {
        foreach (var __cooldown in _cooldowns)
        {
            _cooldowns[__cooldown.Key] = __cooldown.Value - Time.deltaTime;
            if (_cooldowns[__cooldown.Key] <= 0)
            {
                _cooldowns.Remove(__cooldown.Key);
                Debug.Log("ability removed from cooldown");
            }
        }
    }
}
