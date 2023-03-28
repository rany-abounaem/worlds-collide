using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    Slider _slider;

    public void Setup(Creature creature)
    {
        creature.Stats.OnHealthUpdate += UpdateHealthUI;
    }

    private void UpdateHealthUI(float health, float maxHealth)
    {
        _slider.value = health / maxHealth;
    }
}
