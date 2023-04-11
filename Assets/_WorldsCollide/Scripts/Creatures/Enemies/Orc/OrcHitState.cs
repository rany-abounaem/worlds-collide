using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrcHitState : State
{
    private State _previousState;
    private DamageDetails _damageDetails;

    public OrcHitState(Orc self, State previousState, DamageDetails damageDetails) : base(self)
    {
        _previousState = previousState;
        _damageDetails = damageDetails;
    }

    public override void Enter()
    {
        base.Enter();
        var __playDuration = 1 - _damageDetails.StaggerDuration;
        _self.Anim.Play("Hit", 0, __playDuration);
        _self.Anim.Update(Time.deltaTime);
    }

    public override void Update()
    {
        if (!_self.Anim.GetNextAnimatorStateInfo(0).IsName("Hit"))
        {
            if (_self.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                Debug.Log("Normalized time " + _self.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                _self.SetState(_previousState);
            }
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
