using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntCallback(int x);
public delegate void FloatCallback(float x);

public class PlayerStatsComponent : StatsComponent
{
    [SerializeField]
    private float _experiencePoints;
    private float _maxExperiencePoints;
    [SerializeField]
    private int _level = 1;

    public event IntCallback OnLevelUpdated;
    public event BarUpdateCallback OnExperienceUpdated; 

    private FloatModifier dexterity;

    private void Awake()
    {
        _maxExperiencePoints = Mathf.Pow(_level + 1, 2);
    }

    public float GetExperiencePoints()
    {
        return _experiencePoints;
    }

    public void AddExperiencePoints(float exp)
    {
        _experiencePoints += exp;
        if (exp >= _maxExperiencePoints)
        {
            _level = (int)Mathf.Sqrt(exp);
            _maxExperiencePoints = Mathf.Pow(_level + 1, 2);
            OnLevelUpdated?.Invoke(_level);
        }
        OnExperienceUpdated?.Invoke(_experiencePoints, _maxExperiencePoints);
    }

}
