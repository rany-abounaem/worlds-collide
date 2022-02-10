using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightIdleState : State
{
    public PlateKnightIdleState(GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb) : base(_npc, _ai, _anim, _player, _rb)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetBool("isIdle", true);
        Debug.Log("Idle set");
        base.Enter();
    }

    public override void Update()
    {
        
        if (Random.Range (0, 1000) < 10)
        {
            nextState = new PlateKnightPatrolState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        anim.SetBool("isIdle", false);
        Debug.Log("Idle unset");
        //anim.ResetTrigger("isIdle");

        base.Exit();

    }
}
