using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    [field: SerializeField]
    public Weapon Weapon { get; private set; }
    public BoxCollider2D Collider { get; private set; }

    public void Setup()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    public void SetWeapon(Weapon weapon)
    {
        Weapon = weapon;
        Collider.size = weapon.GetHitbox().size;
    }

    public List<IDamageable> GetCollisions()
    {
        var __colliders = new List<Collider2D>();
        Collider.OverlapCollider(new ContactFilter2D().NoFilter(), __colliders);

        var __damageables = new List<IDamageable>();
        foreach (var __collider in __colliders)
        {
            if (__collider.TryGetComponent(out IDamageable __damageable))
            {
                Debug.Log(__collider.name);
                __damageables.Add(__damageable);
            }
        }
        return __damageables;
    }
}
