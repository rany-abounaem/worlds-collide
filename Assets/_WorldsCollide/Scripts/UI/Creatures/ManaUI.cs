using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    [SerializeField]
    Slider _slider;

    public void Setup(Creature creature)
    {
        creature.Stats.OnManaUpdate += UpdateManaUI;
    }

    private void UpdateManaUI(float mana, float maxMana)
    {
        _slider.value = mana / maxMana;
    }
}
