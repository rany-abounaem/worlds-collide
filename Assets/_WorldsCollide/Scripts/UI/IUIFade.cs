using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIFade
{
    public void Fade(float target, float duration);
    public void FadeLoop(float duration, int repetitions);
}
