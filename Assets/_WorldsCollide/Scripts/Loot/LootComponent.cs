using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootComponent : MonoBehaviour
{
    [SerializeField]
    Loot[] _loot;

    public Loot[] GetLootList()
    {
        return _loot;
    }
}
