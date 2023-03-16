using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    List<Ability> _abilities = new List<Ability>();
    CooldownManager _cooldownManager;

    public void UseAbility(int index)
    {
        var __ability = _abilities[index];
        var __abilityName = __ability.GetAbilityName();

        if (_cooldownManager.AbilityOnCooldown(__abilityName) == -1)
        {
            var __cooldown = __ability.GetCooldown();
            _cooldownManager.AddCooldown(__abilityName, __cooldown);
            __ability.Use();
        }
        
        
    }
}
