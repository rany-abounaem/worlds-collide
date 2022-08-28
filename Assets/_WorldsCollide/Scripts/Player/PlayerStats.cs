using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public float Health { get; set; } = 100f;
    public float MaxHealth { get; set; }  = 100f;
    public int DefensePower { get; set; } = 1;
    public int AttackPower { get; set; } = 1;

    public UnityEvent onHealthUpdate;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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

    public bool TakeDamage (int value)
    {
        Health -= value;
        onHealthUpdate.Invoke();

        Instantiate(GameManager.instance.BloodEffect, transform.position, Quaternion.identity);
        GameObject damagePopup = Instantiate(GameManager.instance.DamagePopup, transform.position, Quaternion.identity);
        TextPopupManager textPopupManager = damagePopup.GetComponent<TextPopupManager>();
        textPopupManager.text = value.ToString();
        damagePopup.SetActive(true);
        
        if (Health <= 0)
        {
            Health = 0;
            return true;
        }
        else return false;
    }
}
