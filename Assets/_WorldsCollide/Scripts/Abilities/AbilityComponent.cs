using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void AbilityCallback();

public class AbilityComponent : MonoBehaviour
{
    [SerializeField]
    private List<Ability> _abilities = new List<Ability>();
    private CooldownManager _cooldownManager = new CooldownManager();
    private Ability _currentAbility;

    private Creature _creature;

    public event AbilityCallback OnAbilityAdded;

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
            __abilityName = __ability.GetName();
            if (__abilityName.Equals(name) && _cooldownManager.AbilityOnCooldown(__abilityName) == -1)
            {
                var __cooldown = __ability.GetCooldown();
                _cooldownManager.AddCooldown(__abilityName, __cooldown);
                __ability.Use();
                _currentAbility = __ability;
            }
        }
    }

    public void AddAbility(Ability ability)
    {
        if (_abilities.Contains(ability))
        {
            return;
        }
        else
        {
            _abilities.Add(ability);
            OnAbilityAdded?.Invoke();
        }
    }

    public List<Ability> GetAbilities()
    {
        return _abilities;
    }

    public List<Ability> GetAbilities(int firstIndex, int count)
    {
        var __paginatedAbilities = _abilities.Skip(firstIndex).Take(count).ToList();
        return __paginatedAbilities;
    }

    private void Update()
    {
        _cooldownManager.Tick(Time.deltaTime);
    }
}
