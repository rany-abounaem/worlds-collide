using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{

    private void Start()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorInWorldPos - (Vector2)transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * 15;


        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            AI enemyAI = collision.gameObject.GetComponent<AI>();
            enemyAI.TakeDamage(EquipmentManager.instance.Weapon.AttackPower);
            GameObject psGameObject = Instantiate(GameplaySystem.instance.BloodEffect, transform.position, Quaternion.identity);
            //ParticleSystem ps = psGameObject.GetComponent<ParticleSystem>();
            //var vel = ps.velocityOverLifetime;
            //vel.enabled = true;
            //if (PlayerController.instance.faceRight)
            //{
            //    vel.x = 5;
            //    vel.y = 5;
            //}
            //else
            //{
            //    vel.x = -5;
            //    vel.y = 5;
            //}

            //ps.Play();
        }
    }
}
