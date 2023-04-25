using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void BarUpdateCallback(float value, float maxValue);

public class StatsComponent : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _maxHealth;
    public int DefensePower { get; private set; } = 1;
    public int AttackPower { get; private set; } = 1;

    [SerializeField]
    private float _mana;
    [SerializeField]
    private float _maxMana;

    public event BarUpdateCallback OnHealthUpdate;
    public event BarUpdateCallback OnManaUpdate;

    public event DeathCallback OnDeath;

    public void UpdatePlayerStatsOnEquip(Weapon weapon)
    {
        AttackPower += weapon.AttackPower;
    }
    public void UpdatePlayerStatsOnEquip(Armor armor)
    {
        DefensePower += armor.DefensePower;
        Debug.Log(DefensePower);
    }
    public void UpdatePlayerStatsOnEquip(Cosmetic weapon)
    {
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void ReduceHealth(float value)
    {
        _health -= value;
        if (_health <= 0)
        {
            _health = 0;
        }
        OnHealthUpdate?.Invoke(_health, _maxHealth);
    }

    public float GetMana()
    {
        return _mana;
    }

    public float GetMaxMana()
    {
        return _maxMana;
    }

    public void ReduceMana(float value)
    {
        _mana -= value;
        if (_mana <= 0)
        {
            _mana = 0;
        }
        OnManaUpdate?.Invoke(_mana, _maxMana);
    }
}
