using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightThrow : Ability
{
    float throwForce = 20;
    GameObject spear;

    public override void Use()
    {
        //GameObject instantiatedSpear = MonoBehaviour.Instantiate(spear, Caster.transform.position, Quaternion.identity);
        //Rigidbody2D rb = instantiatedSpear.GetComponent<Rigidbody2D>();
        //Vector2 direction = (Vector2)(MovementComponent.instance.transform.position - Caster.transform.position);
        //instantiatedSpear.transform.up = direction.normalized;
        //rb.velocity = direction.normalized * throwForce;

    }
}
