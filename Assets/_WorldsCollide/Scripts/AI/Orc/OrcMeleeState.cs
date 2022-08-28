using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMeleeState : State
{
    public OrcMeleeState(GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb) : base(_npc, _ai, _anim, _player, _rb)
    {
        name = STATE.MELEE;
    }

    public override void Enter()
    {
        anim.SetBool("isAttacking", true);
        Debug.Log("Attack set");
        base.Enter();
    }


    public override void Update()
    {
        if (Vector2.Distance(npc.transform.position, player.transform.position) < 1.4f ||
            (npc.transform.localScale.x < 0 && npc.transform.position.x < player.transform.position.x) ||
            (npc.transform.localScale.x > 0 && npc.transform.position.x > player.transform.position.x) ||
            Vector2.Distance(npc.transform.position, player.transform.position) > 2.5f)
        {
            nextState = new OrcPatrolState(npc, ai, anim, player, rb);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.SetBool("isAttacking", false);
        Debug.Log("Attack unset");
        base.Exit();
    }
}
