using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    InventoryComponent _inventoryManager;

    [SerializeField]
    Transform _items;

    private void Awake()
    {
        _inventoryManager.OnInventoryChanged += UpdateSlots;
    }

    private void OnEnable()
    {
        UpdateSlots();
    }

    void UpdateSlots()
    {
        SlotUI __currentSlot;
        for (int __i = 0; __i < _inventoryManager.inventory.Count; __i++)
        {
            __currentSlot = _items.GetChild(__i).GetComponent<SlotUI>();
            __currentSlot.UpdateSlot(_inventoryManager.GetItem(__i));
        }
    }
}
