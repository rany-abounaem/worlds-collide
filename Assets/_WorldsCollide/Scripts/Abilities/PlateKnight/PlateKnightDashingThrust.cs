using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightDashingThrust : Ability
{
    GameObject spear;
    GameObject shield;

    public override void Use()
    {
        //BoxCollider2D spearCollider = spear.GetComponent<BoxCollider2D>();
        //Collider2D[] colliders = new Collider2D [5];
        //ContactFilter2D filter = new ContactFilter2D();
        //spearCollider.OverlapCollider(filter, colliders);
        //foreach (Collider2D collider in colliders)
        //{
        //    if (collider != null)
        //    {
        //        if (collider.CompareTag("Player"))
        //        {
        //            StatsComponent playerStats = collider.gameObject.GetComponent<StatsComponent>();
        //            playerStats.TakeDamage(20);
        //        }
        //    }
        //    else

        //    {
        //        break;
        //    }

        //}
    }
}
