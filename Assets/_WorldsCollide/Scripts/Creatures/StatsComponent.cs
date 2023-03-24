using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void DeathCallback(GameObject obj);

public class StatsComponent : MonoBehaviour
{
    public float Health { get; set; } = 100f;
    public float MaxHealth { get; set; }  = 100f;
    public int DefensePower { get; set; } = 1;
    public int AttackPower { get; set; } = 1;

    public UnityEvent onHealthUpdate;

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

    public void TakeDamage (float value)
    {
        Health -= value;
        onHealthUpdate.Invoke();

        Instantiate(GameplaySystem.instance.BloodEffect, transform.position, Quaternion.identity);
        GameObject damagePopup = Instantiate(GameplaySystem.instance.DamagePopup, transform.position, Quaternion.identity);
        TextPopupManager textPopupManager = damagePopup.GetComponent<TextPopupManager>();
        textPopupManager.text = value.ToString();
        damagePopup.SetActive(true);
        
        if (Health <= 0)
        {
            Health = 0;
            OnDeath?.Invoke(gameObject);
        }
    }
}
