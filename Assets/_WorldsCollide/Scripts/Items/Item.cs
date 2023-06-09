using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item", order = 1)]

public class Item : ScriptableObject, ISlottable
{
    [SerializeField]
    private string _itemName;
    [SerializeField]
    private string _description;
    [SerializeField]
    private int _spriteId;
    [SerializeField]
    private int _quantity;
    [SerializeField]
    private int _cost;
    [SerializeField]
    private Sprite _sprite;

    public string GetName()
    {
        return _itemName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }

    public int GetSpriteId()
    {
        return _spriteId;
    }

    public void SetQuantity(int quantity)
    {
        _quantity= quantity;
    }
}

