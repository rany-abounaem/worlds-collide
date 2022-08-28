using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventory;
    public UnityEvent onInventoryChanged;
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

    public void AddToInventory(Item item)
    {
        inventory.Add(item);
        onInventoryChanged.Invoke();
    }

    public bool RemoveFromInventory (Item item)
    {
        if (inventory.Remove(item))
        {
            onInventoryChanged.Invoke();
            return true;
        }
        else
            return false;  
    }
    
    public Item GetItemFromInventory (int index)
    {
        if (inventory[index] != null)
            return inventory[index];
        else return null;
    }
}
