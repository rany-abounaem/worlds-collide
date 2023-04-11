using UnityEngine;

public class OrcChaseState : State
{
    private Creature _target;
    private OrcPatrolState _patrolState;
    private OrcMeleeState _meleeState;
    public OrcChaseState(Orc self, Creature target, OrcPatrolState patrolState) : base(self)
    {
        _self = self;
        _target = target;
        _patrolState = patrolState;
    }

    public override void Enter()
    {
        base.Enter();
        _self.Target = _target;
        _self.Anim.Play("Chase");
        _self.OnTakeDamage += TransitionToHitState;
        var __movementSpeed = _self.Movement.GetMovementSpeed();
        _self.Movement.SetMovementSpeed(__movementSpeed * 1.5f);
    }

    public override void Update()
    {
        base.Update();
        Chase();
        CheckTarget();
    }

    public override void Exit()
    {
        base.Exit();
        _self.Target = null;
        _self.OnTakeDamage -= TransitionToHitState;
        var __movementSpeed = _self.Movement.GetMovementSpeed();
        _self.Movement.SetMovementSpeed(__movementSpeed / 1.5f);
        _self.Movement.SetMovementInput(0);
    }

    private void Chase()
    {
        if (_target.transform.position.x > _self.transform.position.x)
        {
            _self.Movement.SetMovementInput(1);
        }
        else
        {
            _self.Movement.SetMovementInput(-1);
        }
    }

    private void CheckTarget()
    {
        if (Vector2.Distance(_target.transform.position, _self.transform.position) > _self.GetAggroRange())
        {
            _self.SetState(_patrolState);
        }

        if (Vector2.Distance(_target.transform.position, _self.transform.position) < 2f)
        {
            if (_meleeState == null)
            {
                _meleeState = new OrcMeleeState((Orc)_self, _target, this);
            }
            _self.SetState(_meleeState);
        }
    }

    private void TransitionToHitState(DamageDetails damageDetails)
    {
        _self.SetState(new OrcHitState((Orc)_self, this, damageDetails));
    }
}
