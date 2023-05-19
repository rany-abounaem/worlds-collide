using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SlotUI : MonoBehaviour
{
    [SerializeField]
    Image _itemUI;
    public IStorable SlotItem { get; private set; }

    public void UpdateSlot(IStorable storableItem)
    {
        SlotItem = storableItem;
        _itemUI.sprite = storableItem.GetSprite();
    }
}
