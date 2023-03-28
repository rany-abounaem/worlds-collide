using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Loot
{
    public Item lootItem;
    public int minQuanitity;
    public int maxQuantity;
    public float probability;
}
