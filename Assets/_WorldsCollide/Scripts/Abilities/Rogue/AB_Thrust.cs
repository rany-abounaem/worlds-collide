using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability_Thrust", menuName = "ScriptableObjects/Abilities/Rogue/Thrust")]
public class AB_Thrust : Ability
{
    public override void Setup(Creature creature)
    {
        base.Setup(creature);
        var __animClips = _animator.runtimeAnimatorController.animationClips;

        var __animEvent = new AnimationEvent
        {
            time = 0.333f,
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
                var __damageables = ((Player)_caster).Equipment.GetLeftWeapon().GetCollisions();
                foreach (var __damageable in __damageables)
                {
                    __damageable.TakeDamage(10);
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
