using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item", order = 1)]

public class Item : ScriptableObject
{
    [SerializeField]
    public string _itemName { get; set; }
    [SerializeField]
    public int _spriteId { get; set; }
    [SerializeField]
    public int _quantity { get; set; }
    [SerializeField]
    public int _cost { get; set; }
    [SerializeField]
    public Sprite _sprite { get; set; }

    public string GetItemName()
    {
        return _itemName;
    }

    public int GetItemSpriteId()
    {
        return _spriteId;
    }
}

