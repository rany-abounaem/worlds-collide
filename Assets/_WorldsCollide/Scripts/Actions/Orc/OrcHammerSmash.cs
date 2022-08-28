using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHammerSmash : Action
{
    public GameObject hammer;
    public OrcHammerSmash(GameObject _caster, GameObject _hammer) : base(_caster)
    {
        hammer = _hammer;
    }

    public override void UseAction()
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
                    PlayerStats.instance.TakeDamage(20);
                }
            }
            else

            {
                break;
            }

        }
    }
}
