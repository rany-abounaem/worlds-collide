using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    protected GameObject caster;
    protected int energyCost;
    protected int range;

    public Action(GameObject _caster)
    {
        caster = _caster;
        energyCost = 10;
        range = 10;
    }
    virtual public void UseAction()
    {
        Debug.Log("Used action");
    }
}
