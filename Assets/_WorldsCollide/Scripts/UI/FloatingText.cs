using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private float _maxTime;
    private float _timeElapsed;
    private float _floatingSpeed;
    private float _scalingSpeed;
    private TextMeshPro _textComponent;

    public event FloatingTextCallback OnTimeEnd;

    public void Setup(string text, Color color, float maximumTime, float floatingSpeed, float scalingSpeed)
    {
        _textComponent = GetComponent<TextMeshPro>();
        _maxTime = maximumTime;
        _timeElapsed = 0;
        _floatingSpeed = floatingSpeed;
        _textComponent.text = text;
        _textComponent.color = color;
        _scalingSpeed = scalingSpeed;
    }

    private void Update()
    {
        var __delta = Time.deltaTime;
        var __pos = transform.position;
        transform.position = new Vector2(__pos.x, __pos.y + (_floatingSpeed * __delta));
        var __ratio = _timeElapsed / _maxTime;
        var __scale = Mathf.Clamp(__ratio, 0, 1);
        transform.localScale = new Vector2(1 - __scale, 1 - __scale);
        _timeElapsed += __delta;
        if (_timeElapsed >= _maxTime)
        {
            OnTimeEnd?.Invoke(this);
        }
    }

    public float GetTimeElapsed()
    {
        return _timeElapsed;
    }

    public float GetMaxTime()
    {
        return _maxTime;
    }

}
