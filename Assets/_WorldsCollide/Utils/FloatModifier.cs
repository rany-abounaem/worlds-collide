using System;

public class FloatModifier
{
    private float _baseValue;
    private float _modifiedValue;

    public float GetBaseValue()
    {
        return _baseValue;
    }

    public float GetModifiedValue()
    {
        return _modifiedValue;
    }

    public void AddValue(float value)
    {
        _modifiedValue = _modifiedValue + value;
    }

    public void MultiplyValue(float value)
    {
        _modifiedValue = (_baseValue * value) + _modifiedValue;
    }
}
