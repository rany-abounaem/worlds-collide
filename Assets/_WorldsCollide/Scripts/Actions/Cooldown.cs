using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown 
{
    
    public string _name;
    public float _timeRemaining;

    public Cooldown(string name, float time)
    {
        _name = name;
        _timeRemaining = time;
    }
}
