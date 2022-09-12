using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsCollide.UI
{
    public interface IUIFade
    {
        public void Fade(float target, float duration);
        public void FadeLoop(float target, float duration, int repetitions);
    }
}

