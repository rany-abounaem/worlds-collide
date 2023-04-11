using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPatrolState : State
{
    private float _movementInput;
    private OrcChaseState _chaseState;

    public OrcPatrolState(Orc self) : base(self)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _self.Target = null;
        _self.Anim.Play("Walk");
        _self.OnTakeDamage += TransitionToHitState;
        _self.GetDetectionArea().OnDetection += HandleDetection;
    }

    public override void Update()
    {
        base.Update();
        Walk();
        CheckLocation();
    }

    public override void Exit()
    {
        base.Exit();
        StopWalking();
        _self.OnTakeDamage -= TransitionToHitState;
    }

    private void TransitionToHitState(DamageDetails damageDetails)
    {
        _self.SetState(new OrcHitState((Orc)_self, this, damageDetails));
    }

    void Walk()
    {
        _self.Movement.SetMovementInput(_movementInput);
    }

    void StopWalking()
    {
        _self.Movement.SetMovementInput(0);
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

    void HandleDetection(Creature player)
    {
        if (_chaseState == null)
        {
            _chaseState = new OrcChaseState((Orc)_self, player, this);
        }
        _self.SetState(_chaseState);

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
