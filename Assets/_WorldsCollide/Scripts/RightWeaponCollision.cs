using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeaponCollision : MonoBehaviour
{
    BoxCollider2D weaponCollider;

    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        MovementComponent.instance.rightWeaponHit.AddListener(() => Hit());
    }

    public void Hit()
    {
        Collider2D[] colliders = new Collider2D[5];
        ContactFilter2D filter = new ContactFilter2D();
        weaponCollider.OverlapCollider(filter, colliders);
        foreach (Collider2D collider in colliders)
        {
            if (collider != null)
            {
                if (collider.CompareTag("Enemy"))
                {
                    AI enemyAI = collider.gameObject.GetComponent<AI>();
                    enemyAI.TakeDamage(EquipmentManager.instance.Weapon.AttackPower);
                    GameObject psGameObject = Instantiate(GameplaySystem.instance.BloodEffect, transform.position, Quaternion.identity);
                }
            }
            else

            {
                break;
            }

        }
    }
}
