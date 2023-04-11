using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcIdleState : State
{

    public OrcIdleState(Orc self) : base(self)
    {
    }

    public override void Enter()
    {
        _self.Anim.Play("Idle");
        base.Enter();
    }

    public override void Update()
    {
        //Random chance to patrol
        if (Random.Range(0, 1000) < 10)
        {
            _self.SetState(new OrcPatrolState((Orc)_self));
        }

    }

    public override void Exit()
    {
        base.Exit();

    }
}
