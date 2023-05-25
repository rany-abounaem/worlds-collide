using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SlotUI : MonoBehaviour
{
    protected int _slotIndex;
    [SerializeField]
    private Sprite _emptySlotSprite;
    [SerializeField]
    private Image _itemUI;

    private ISlottable _slottable;
    public ISlottable GetSlottable() { return _slottable; }

    public virtual void UpdateSlot(ISlottable slottable)
    {
        _slottable = slottable;
        if (slottable == null)
        {
            _itemUI.sprite = _emptySlotSprite;
            return;
        }
        _itemUI.sprite = slottable.GetSprite();
    }

    public Image GetImage()
    {
        return _itemUI;
    }

    public void SetSlotIndex(int index)
    {
        _slotIndex = index;
    }

    public int GetSlotIndex() { return _slotIndex;}
}
