using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPatrolState : State
{
    private float _movementInput;

    public OrcPatrolState(Orc self) : base(self)
    {
        
    }

    public override void Enter()
    {
        _self.Animator.Play("Walk");
        base.Enter();
    }

    public override void Update()
    {
        Walk();
        CheckLocation();
        //CheckSurrounding();
    }

    public override void Exit()
    {
        base.Exit();
    }

    void Walk()
    {
        _self.Movement.SetMovement(_movementInput);
    }

    void CheckLocation()
    {
        if (_self.transform.position.x < ((Orc)_self).GetWaypoints()[0].position.x)
        {
            _movementInput = 1;
            
        }
        else if (_self.transform.position.x > ((Orc)_self).GetWaypoints()[1].position.x)
        {
            _movementInput = -1;
            
        }
    }

    //void CheckSurrounding()
    //{
    //    float distance = Vector2.Distance(npc.transform.position, player.position);
    //    float scaleX = npc.transform.localScale.x;

    //    if (distance <= 2.5f && distance >= 1.4f)
    //    {
    //        int chance = Random.Range(0, 1000);
    //        if (chance < 100)
    //        {
    //            nextState = new OrcMeleeState(npc, ai, anim, player, rb);
    //            stage = EVENT.EXIT;
    //        }
    //    }
    //}
}
