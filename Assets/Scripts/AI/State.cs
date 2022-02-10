using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum STATE { IDLE, PATROL, MELEE, THROW, CAST }
    public enum EVENT { ENTER, UPDATE, EXIT }


    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected Rigidbody2D rb;
    protected AI ai;

    float aggroRange = 10f;

    public State (GameObject _npc, AI _ai, Animator _anim, Transform _player, Rigidbody2D _rb)
    {
        npc = _npc;
        ai = _ai;
        anim = _anim;
        player = _player;
        rb = _rb;
        stage = EVENT.ENTER;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process()
    {
        if (stage == EVENT.ENTER)
        {
            Enter();
        }

        else if (stage == EVENT.UPDATE)
        {
            Update();
        }

        else if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}
