using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKnightThrowState : State
{
    public PlateKnightThrowState(GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb) : base(_npc, _ai, _anim, _player, _rb)
    {
        name = STATE.THROW;
    }

    public override void Enter()
    {
        anim.SetBool("isThrowing", true);
        Debug.Log("Throw set");
        base.Enter();
    }

    public override void Update()
    {
        float distance = Vector2.Distance(npc.transform.position, player.position);
        if (distance > 8f)
        {
            nextState = new PlateKnightPatrolState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }
        else if (distance <= 4f && distance >= 1.4f)
        {
            int chance = Random.Range(0, 1000);
            if (chance < 10)
            {
                nextState = new PlateKnightMeleeState(npc, ai, anim, player, rb);
                stage = EVENT.EXIT;
            }
        }
        

    }

    public override void Exit()
    {
        anim.SetBool("isThrowing", false);
        Debug.Log("Throw unset");
        base.Exit();

    }
}
