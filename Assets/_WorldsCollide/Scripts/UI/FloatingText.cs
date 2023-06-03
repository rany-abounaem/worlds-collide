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

    public void Tick()
    {
        var __delta = Time.deltaTime;
        var __pos = transform.position;
        transform.position = new Vector2(__pos.x, __pos.y + (_floatingSpeed * __delta));
        var __scale = transform.localScale;
        var __ratio = _maxTime / (_timeElapsed + 0.01f);
        var __scaleX = Mathf.Clamp(__scale.x - __ratio, 0, 1);
        var __scaleY = Mathf.Clamp(__scale.y - __ratio, 0, 1);
        transform.localScale = new Vector2(__scaleX, __scaleY);
        _timeElapsed += __delta;
        if (_timeElapsed >= _maxTime)
        {
            OnTimeEnd?.Invoke(this);
        }
    }

}
