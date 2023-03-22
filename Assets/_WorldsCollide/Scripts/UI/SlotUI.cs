using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField]
    Image _itemUI;
    public Item SlotItem { get; private set; }

    public void UpdateSlot(Item item)
    {
        SlotItem = item;
        _itemUI.sprite = item.GetSprite();
    }
}
