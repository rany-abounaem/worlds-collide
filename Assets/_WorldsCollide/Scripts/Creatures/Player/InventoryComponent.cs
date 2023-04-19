using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void InventoryHandler();

public class InventoryComponent : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public event InventoryHandler OnInventoryChanged;

    public void AddItem(Item item)
    {
        inventory.Add(item);
        OnInventoryChanged?.Invoke();
    }

    public bool RemoveItem (Item item)
    {
        if (inventory.Remove(item))
        {
            OnInventoryChanged?.Invoke();
            return true;
        }
        else
            return false;  
    }
    
    public Item GetItem (int index)
    {
        if (inventory[index] != null)
            return inventory[index];
        else return null;
    }
}
