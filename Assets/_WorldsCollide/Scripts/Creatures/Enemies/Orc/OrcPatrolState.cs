using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPatrolState : State
{
    float moveSpeed = 7;

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
        _self.Rigidbody.velocity = new Vector2(0, 0);
        base.Exit();
    }

    void Walk()
    {
        int factor = _self.transform.localScale.x > 0 ? 1 : -1;
        _self.Rigidbody.velocity = new Vector2(factor * moveSpeed, _self.Rigidbody.velocity.y);
    }

    void CheckLocation()
    {
        if ((_self.transform.position.x < ((Orc)_self).GetWaypoints()[0].position.x && _self.transform.localScale.x < 0) ||
            _self.transform.position.x > ((Orc)_self).GetWaypoints()[1].position.x && _self.transform.localScale.x > 0)
        {

            _self.transform.localScale = new Vector2(-_self.transform.localScale.x, _self.transform.localScale.y);
            _self.SetState(new OrcIdleState((Orc)_self));
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
