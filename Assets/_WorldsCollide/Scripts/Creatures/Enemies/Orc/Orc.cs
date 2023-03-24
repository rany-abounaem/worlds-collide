using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemy
{
    [SerializeField]
    Transform[] _waypoints;
    public override void Setup()
    {
        base.Setup();
        CurrentState = new OrcIdleState(this);
        Debug.Log(CurrentState);
    }

    public Transform[] GetWaypoints()
    {
        return _waypoints;
    }

}
