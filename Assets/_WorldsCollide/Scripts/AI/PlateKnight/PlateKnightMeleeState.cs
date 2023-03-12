using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightMeleeState : State
{

    EnemyStats enemyStats;
    bool upSpear = false;

    public PlateKnightMeleeState(GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb) : base(_npc, _ai, _anim, _player, _rb)
    {
        name = STATE.MELEE;
    }

    //Set trigger based on best action trigger string
    public override void Enter()
    {
        if (MovementComponent.instance.IsGrounded)
        {
            anim.SetBool("isAttacking", true);
            upSpear = false;
        }
        else
        {
            upSpear = true;
            anim.SetBool("isAttacking1", true);
        }
        Debug.Log("Attack set");
        base.Enter();
    }


    public override void Update()
    {
        if (
            Vector2.Distance(npc.transform.position, player.transform.position) < 1.4f ||
            (npc.transform.localScale.x < 0 && npc.transform.position.x < player.transform.position.x) ||
            (npc.transform.localScale.x > 0 &&  npc.transform.position.x > player.transform.position.x))
        {
            nextState = new PlateKnightPatrolState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }

        //Condition: If the distance increases, throw instead
        else if (Vector2.Distance(npc.transform.position, player.transform.position) > 4f)
        {
            nextState = new PlateKnightThrowState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }

        //Condition: If the player is on the ground and plate knight is attacking upwards
        else if (MovementComponent.instance.IsGrounded && upSpear)
        {
            nextState = new PlateKnightMeleeState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }

        //Condition: If the player is in the air and plate knight is attacking downwards
        else if (!MovementComponent.instance.IsGrounded && !upSpear)
        {
            nextState = new PlateKnightMeleeState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.SetBool("isAttacking1", false);
        anim.SetBool("isAttacking", false);
        Debug.Log("Attack unset");
        base.Exit();
    }
}
