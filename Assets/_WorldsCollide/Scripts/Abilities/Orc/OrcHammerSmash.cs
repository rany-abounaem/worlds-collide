using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHammerSmash : Ability
{
    public GameObject hammer;
    public OrcHammerSmash(GameObject _caster, GameObject _hammer) : base(_caster)
    {
        hammer = _hammer;
    }

    public override void Use()
    {
        BoxCollider2D hammerCollider = hammer.GetComponent<BoxCollider2D>();
        Collider2D[] colliders = new Collider2D[5];
        ContactFilter2D filter = new ContactFilter2D();
        hammerCollider.OverlapCollider(filter, colliders);
        foreach (Collider2D collider in colliders)
        {

            if (collider != null)
            {
                if (collider.CompareTag("Player"))
                {
                    StatsComponent.instance.TakeDamage(20);
                }
            }
            else

            {
                break;
            }

        }
    }
}
