using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionsBarSlotUI : SlotUI
{
    private string _slotHotkey;

    [SerializeField]
    private Image _cdFill;
    [SerializeField]
    private TextMeshProUGUI _cdTimer;
    [SerializeField]
    private TextMeshProUGUI _slotHotkeyText;

    public void UpdateSlotHotkey(string slotHotkey)
    {
        _slotHotkey = slotHotkey;
    }
}
