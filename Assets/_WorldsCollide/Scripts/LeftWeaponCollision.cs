using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeaponCollision : MonoBehaviour
{
    BoxCollider2D weaponCollider;

    private void Start()
    {
        weaponCollider = GetComponent<BoxCollider2D>();
        MovementComponent.instance.leftWeaponHit.AddListener(() => Hit());
    }

    public void Hit()
    {
        Collider2D[] colliders = new Collider2D[5];
        ContactFilter2D filter = new ContactFilter2D();
        weaponCollider.OverlapCollider(filter, colliders);
        foreach(Collider2D collider in colliders)
        {
            if(collider!=null)
            {
                if (collider.CompareTag("Enemy"))
                {
                    AI enemyAI = collider.gameObject.GetComponent<AI>();
                    enemyAI.TakeDamage(10);
                    GameObject psGameObject = Instantiate(GameplaySystem.instance.BloodEffect, transform.position, Quaternion.identity);
                }
            }
            else

            {
                break;
            }
            
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Enemy") && PlayerController.instance.isAttacking)
    //    {
    //        Debug.Log("Taking Damage");
    //        EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
    //        enemyStats.TakeDamage(EquipmentManager.instance.Weapon.AttackPower);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    hit = false;
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy") && PlayerController.instance.isAttacking && hit == false)
    //    {
    //        Debug.Log("Taking Damage");
    //        EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
    //        enemyStats.TakeDamage(EquipmentManager.instance.Weapon.AttackPower);
    //        hit = true;
    //    }
    //}
    //public void Check()
    //{

    //}
}
