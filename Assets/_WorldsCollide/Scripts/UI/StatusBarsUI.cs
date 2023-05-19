using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarsUI : UIPanel
{
    [SerializeField]
    private HealthUI _healthUI;
    [SerializeField]
    private ManaUI _manaUI;
    [SerializeField]
    private LevelUI _levelUI;

    public override void Setup(Player player)
    {
        _healthUI.Setup(player);
        _manaUI.Setup(player);
        _levelUI.Setup(player);
    }
}
