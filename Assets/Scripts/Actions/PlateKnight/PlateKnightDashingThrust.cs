using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightDashingThrust : Action
{
    GameObject spear;
    GameObject shield;

    public PlateKnightDashingThrust(GameObject _caster, GameObject _spear, GameObject _shield): base(_caster)
    {
        spear = _spear;
        shield = _shield;
    }

    public override void UseAction()
    {
        BoxCollider2D spearCollider = spear.GetComponent<BoxCollider2D>();
        Collider2D[] colliders = new Collider2D [5];
        ContactFilter2D filter = new ContactFilter2D();
        spearCollider.OverlapCollider(filter, colliders);
        foreach (Collider2D collider in colliders)
        {
            if (collider != null)
            {
                if (collider.CompareTag("Player"))
                {
                    PlayerStats playerStats = collider.gameObject.GetComponent<PlayerStats>();
                    playerStats.TakeDamage(20);
                }
            }
            else

            {
                break;
            }

        }
    }
}
