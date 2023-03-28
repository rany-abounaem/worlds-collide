using System;
using System.Collections;
using System.Collections.Generic;

public class Timer
{
    private float _time;
    public event System.Action OnTimerEnded;
    public Timer(float time)
    {
        _time = time;
    }

    public void Tick(float deltaTime)
    {
        _time -= deltaTime;

        if (_time  <= 0)
        {
            OnTimerEnded?.Invoke();
        }
    }

}
