using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WorldsCollide.MainMenu
{
    public class CustomButtonVisuals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IUIFade
    {
        float _targetAlpha;
        AnimationCurve _curve;
        Coroutine _fadeCoroutine;
        Coroutine _fadeLoopCoroutine;
        CanvasGroup _canvasGroup;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Fade(float target, float duration)
        {
            _curve = AnimationCurve.Linear(0, _canvasGroup.alpha, duration, target);
            _fadeCoroutine = StartCoroutine(StartFade(duration));
        }

        public void FadeLoop(float duration, int repetitions)
        {
            _fadeLoopCoroutine = StartCoroutine(StartFadeLoop(duration, repetitions));
        }

        IEnumerator StartFade(float duration)
        {
            if (_fadeCoroutine != null)
                StopCoroutine(_fadeCoroutine);

            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                _canvasGroup.alpha = _curve.Evaluate(time);
                yield return null;
            }

            _fadeCoroutine = null;
        }
        IEnumerator StartFadeLoop(float duration, int repetitions)
        {
            if (_fadeLoopCoroutine != null)
                StopCoroutine(_fadeLoopCoroutine);

            if (repetitions == -1)
            {
                while (true)
                {
                    if (_fadeCoroutine == null)
                    {
                        repetitions--;
                        if (_canvasGroup.alpha > 0)
                        {
                            Fade(0, duration);
                        }
                        else
                        {
                            Fade(1, duration);
                        }
                    }
                    yield return null;
                }
            }

            else
            {
                while (repetitions > 0)
                {
                    if (_fadeCoroutine == null)
                    {
                        repetitions--;
                        if (_canvasGroup.alpha > 0)
                        {
                            Fade(0, duration);
                        }
                        else
                        {
                            Fade(1, duration);
                        }
                    }
                    yield return null;
                }
            }
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_fadeLoopCoroutine != null)
                StopCoroutine(_fadeLoopCoroutine);
            FadeLoop(1f, -1);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_fadeLoopCoroutine != null)
            {
                StopCoroutine(_fadeLoopCoroutine);
                _fadeLoopCoroutine = null;
            }
            Fade(1, 1);
        }
    }
}

