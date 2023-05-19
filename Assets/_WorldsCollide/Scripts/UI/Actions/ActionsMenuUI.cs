using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionsMenuUI : UIPanel
{
    [SerializeField]
    private RectTransform _slotsParent;

    private int _currentPage;
    private AbilityComponent _abilities;
    private List<ActionsMenuSlotUI> _slots;
    public override void Setup(Player player)
    {
        _abilities = player.Ability;
        _currentPage = 0;
        _slots = _slotsParent.GetComponentsInChildren<ActionsMenuSlotUI>().ToList();
    }

    public override void Open()
    {
        
    }
}
