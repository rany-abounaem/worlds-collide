using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootingBehavior : MonoBehaviour
{
    [SerializeField]
    Loot[] _loot;

    [SerializeField]
    LootDrop _lootDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropLoot()
    {
        foreach (var loot in _loot)
        {
            var chance = Random.Range(0, 100);
            if (chance <= loot.probability)
            {
                var quantity = Random.Range(loot.minQuanitity, loot.maxQuantity + 1);
                var item =  loot.lootItem;
                item._quantity = quantity;
                var __drop = Instantiate(_lootDrop, transform.position, Quaternion.identity);
                __drop.Item = item;
                __drop.Drop();
            }
        }
    }
}
