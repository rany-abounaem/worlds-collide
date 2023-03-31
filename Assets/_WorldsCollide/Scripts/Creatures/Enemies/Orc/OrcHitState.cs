using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrcHitState : State
{
    private float _cliplength;
    private float _time = 0;

    private State _previousState;
    public OrcHitState(Orc self, State previousState) : base(self)
    {
        _previousState = previousState;
    }

    public override void Enter()
    {
        base.Enter();
        _self.Anim.Play("Hit", 0, 0);
        _self.Anim.Update(Time.deltaTime);
    }

    public override void Update()
    {
        if (!_self.Anim.GetNextAnimatorStateInfo(0).IsName("Hit"))
        {
            if (_self.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                _self.SetState(_previousState);
            }
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
