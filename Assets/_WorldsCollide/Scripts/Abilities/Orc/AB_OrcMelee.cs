using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability_OrcMelee", menuName = "ScriptableObjects/Abilities/Orc/Melee")]
public class AB_OrcMelee : Ability
{
    public override void Setup(Creature creature)
    {
        base.Setup(creature);
        var __animClips = _animator.runtimeAnimatorController.animationClips;

        var __animEvent = new AnimationEvent
        {
            time = 0.15f,
            intParameter = 1,
            functionName = "HandleAbilitySequence"
        };

        foreach (var __clip in __animClips)
        {
            Debug.Log(__clip.name);
            if (__clip.name.Equals(_name))
            {
                __clip.AddEvent(__animEvent);
            }
        }

    }
    public override void Use()
    {
        _animator.Play(_name);
    }

    public override void HandleSequence(int sequence)
    {
        base.HandleSequence(sequence);
        switch (sequence)
        {
            case 1:
                var __collider = ((Orc)_caster).GetHammerCollider();
                List<Collider2D> __results = new List<Collider2D>();
                __collider.OverlapCollider(new ContactFilter2D(), __results);
                foreach (var __result in __results)
                {
                    if (__result.TryGetComponent(out Player __player))
                    {
                        Debug.Log("Help");
                        var __damageDetails = new DamageDetails
                        (
                        _caster,
                        DamageType.Physical,
                        _caster.Stats.AttackPower * 10,
                        0.2f
                        );
                        __player.TakeDamage(__damageDetails);
                    }
                }
                break;
            case 2:
                break;
            
        }
    }

    public void PrintMessage(string msg)
    {
        Debug.Log("Animation logged message: " + msg);
    }


}
