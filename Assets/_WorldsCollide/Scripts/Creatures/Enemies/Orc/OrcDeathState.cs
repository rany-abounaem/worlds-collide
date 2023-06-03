using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcDeathState : State
{

    public OrcDeathState(Orc self) : base(self)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _self.Target = null;
        _self.Anim.Play("Death");
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
