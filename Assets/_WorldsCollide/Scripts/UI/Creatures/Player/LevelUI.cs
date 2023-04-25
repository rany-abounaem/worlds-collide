using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    Slider _slider;

    [SerializeField]
    TextMeshProUGUI _levelText;
    [SerializeField]
    TextMeshProUGUI _currentXPText;
    [SerializeField]
    TextMeshProUGUI _maxXPText;
    public void Setup(Player player)
    {
        ((PlayerStatsComponent)player.Stats).OnLevelUpdated += UpdateLevelText;
        ((PlayerStatsComponent)player.Stats).OnExperienceUpdated += UpdateExperienceUI;
    }

    private void UpdateLevelText(int level)
    {
        _levelText.text = "LVL " + level;
    }

    private void UpdateExperienceUI(float experience, float maxExperience)
    {
        _slider.value = experience / maxExperience;
        _currentXPText.text = experience.ToString();
        _maxXPText.text = maxExperience.ToString();
    }
}
