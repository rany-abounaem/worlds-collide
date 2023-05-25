using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionsMenuSlotUI : SlotUI
{
    [SerializeField]
    private TextMeshProUGUI _actionName;
    private Ability _action;

    public override void UpdateSlot(ISlottable slottable)
    {
        base.UpdateSlot(slottable);
        if (slottable == null)
        {
            _actionName.text = "Empty";
            return;
        }
        _actionName.text = slottable.GetName();
        _action = slottable as Ability;
        Debug.Log(_action);
    }

    public Ability GetAbility() { return _action; }
}
