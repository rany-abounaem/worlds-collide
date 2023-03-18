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

        var __animEvent = new AnimationEvent();
        __animEvent.time = 0.333f;
        __animEvent.intParameter = 1;
        __animEvent.functionName = "HandleAbilitySequence";

        foreach (var __clip in __animClips)
        {
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
                Debug.Log("Sequence 1");
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
