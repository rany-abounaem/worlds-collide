using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UIPanel
{
    private InventoryComponent _playerInventory;

    [SerializeField]
    private Transform _items;

    public override void Setup(Player player)
    {
        _playerInventory = player.Inventory;
        _playerInventory.OnInventoryChanged += UpdateSlots;
    }

    private void UpdateSlots()
    {
        SlotUI __currentSlot;
        for (int __i = 0; __i < _playerInventory.inventory.Count; __i++)
        {
            __currentSlot = _items.GetChild(__i).GetComponent<SlotUI>();
            var __item = _playerInventory.GetItem(__i);
            if (__item != null)
            {
                __currentSlot.UpdateSlot(__item);
            }
            
        }
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
