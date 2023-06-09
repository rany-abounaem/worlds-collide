using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void VoidCallback();

public abstract class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected int _slotIndex;
    [SerializeField]
    private Sprite _emptySlotSprite;
    [SerializeField]
    private Image _itemUI;

    public event VoidCallback OnSlotPointerEnter;
    public event VoidCallback OnSlotPointerExit;

    protected ISlottable _slottable;
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

    public virtual string GetSlotTooltip()
    {
        return "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSlotPointerEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnSlotPointerExit?.Invoke();
    }

    //private void OnDisable()
    //{
    //    OnSlotPointerEnter = null;
    //}
}
