using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    [SerializeField]
    Transform[] _waypoints;

    [SerializeField]
    BoxCollider2D _hammerCollider;

    public override void Setup()
    {
        base.Setup();
        CurrentState = new OrcIdleState(this);
        Debug.Log(CurrentState);
        OnDeath += () => { SetState(new OrcDeathState(this));  };
    }

    public Transform[] GetWaypoints()
    {
        return _waypoints;
    }

    public BoxCollider2D GetHammerCollider()
    {
        return _hammerCollider;
    }

}
