using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : UIPanel
{
    private InventoryComponent _playerInventory;

    [SerializeField]
    private Transform _items;

    private List<SlotUI> _slots;

    [SerializeField]
    private TooltipChannel _tooltipChannel;

    public override void Setup(Player player)
    {
        _playerInventory = player.Inventory;
        _playerInventory.OnInventoryChanged += UpdateSlots;

        _slots = new List<SlotUI>(_items.childCount);

        for (int __i = 0; __i < _items.childCount; __i++)
        {
            var __slot = _items.GetChild(__i).GetComponent<SlotUI>();
            __slot.OnSlotPointerEnter += () =>
            {
                if (__slot.GetSlottable() != null)
                {
                    _tooltipChannel.Raise(__slot.gameObject, __slot.GetSlotTooltip());
                }
            };

            __slot.OnSlotPointerExit += () =>
            {
                _tooltipChannel.Cancel(__slot.gameObject);
            };
            _slots.Add(__slot);
        }
    }

    private void UpdateSlots()
    {
        for (int __i = 0; __i < _playerInventory.inventory.Count; __i++)
        {
            var __item = _playerInventory.GetItem(__i);
            if (__item != null)
            {
                _slots[__i].UpdateSlot(__item);
            }
            
        }
    }
}
