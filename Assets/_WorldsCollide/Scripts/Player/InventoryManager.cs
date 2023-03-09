using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void InventoryHandler();

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> inventory;
    public event InventoryHandler OnInventoryChanged;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

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
