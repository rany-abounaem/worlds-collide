using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionsBarSlotUI : SlotUI, IPointerClickHandler
{
    private string _slotHotkey;

    [SerializeField]
    private Image _cdFill;
    [SerializeField]
    private TextMeshProUGUI _cdTimer;
    [SerializeField]
    private TextMeshProUGUI _slotHotkeyText;

    private ISlottable _slottable;

    public event IntCallback OnSlotClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Help");
        OnSlotClick?.Invoke(_slotIndex);
    }

    public void UpdateSlotHotkey(string slotHotkey)
    {
        _slotHotkey = slotHotkey;
    }
}
