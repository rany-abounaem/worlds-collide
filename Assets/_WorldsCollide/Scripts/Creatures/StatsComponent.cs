using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void DeathCallback(GameObject obj);
public delegate void HealthUpdateCallback(float value, float maxValue);

public class StatsComponent : MonoBehaviour
{
    public float Health { get; private set; } = 100f;
    public float MaxHealth { get; private set; }  = 100f;
    public int DefensePower { get; private set; } = 1;
    public int AttackPower { get; private set; } = 1;

    public event HealthUpdateCallback OnHealthUpdate;

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

    public void ReduceHealth(float value)
    {
        Health -= value;
        OnHealthUpdate.Invoke(Health, MaxHealth);

        if (Health <= 0)
        {
            Health = 0;
            OnDeath?.Invoke(gameObject);
        }
    }
}
