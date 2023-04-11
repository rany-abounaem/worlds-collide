using System.Collections;
using UnityEngine;

public class OrcMeleeState : State
{
    private Creature _target;
    private OrcChaseState _chaseState;
    private Coroutine _abilityCoroutine;

    public OrcMeleeState(Orc self, Creature target, OrcChaseState chaseState) : base(self)
    {
        _self = self;
        _target = target;
        _chaseState = chaseState;
    }

    public override void Enter()
    {
        base.Enter();
        _self.Rigidbody.velocity = Vector3.zero;
        _self.Ability.UseAbility("Melee");
        _self.Anim.Update(Time.deltaTime);
        _self.OnTakeDamage += TransitionToHitState;
    }

    public override void Update()
    {
        base.Update();
        CheckAbilityAnim();
    }

    public override void Exit()
    {
        base.Exit();
        _self.OnTakeDamage -= TransitionToHitState;
    }

    private void CheckAbilityAnim()
    {
        var __normalizedTime = _self.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (__normalizedTime >= 1f)
        {
            _self.SetState(_chaseState);
        }
    }

    private void TransitionToHitState(DamageDetails damageDetails)
    {
        _self.SetState(new OrcHitState((Orc)_self, this, damageDetails));
    }
}
