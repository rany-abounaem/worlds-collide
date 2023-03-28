using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    [SerializeField]
    private List<Ability> _abilities = new List<Ability>();
    private CooldownManager _cooldownManager = new CooldownManager();
    private Ability _currentAbility;

    private Creature _creature;

    public void Setup(Creature creature)
    {
        _creature = creature;
        foreach (var __ability in _abilities)
        {
            __ability.Setup(_creature);
        }
    }

    public void HandleAbilitySequence(int sequence)
    {
        _currentAbility.HandleSequence(sequence);
    }

    public void UseAbility(string name)
    {
        string __abilityName;
        foreach(var __ability in _abilities)
        {
            __abilityName = __ability.GetAbilityName();
            if (__abilityName.Equals(name) && _cooldownManager.AbilityOnCooldown(__abilityName) == -1)
            {
                var __cooldown = __ability.GetCooldown();
                _cooldownManager.AddCooldown(__abilityName, __cooldown);
                __ability.Use();
                _currentAbility = __ability;
            }

            
        }
        
        
    }

    private void Update()
    {
        _cooldownManager.Tick(Time.deltaTime);
    }
}
