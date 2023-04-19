using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LootingManager : MonoBehaviour
{
    [SerializeField]
    float lootRate = 1.0f;

    [SerializeField]
    LootDrop _lootDrop;

    public void Setup(EnemiesManager enemiesManager)
    {
        enemiesManager.OnEnemyDeath += HandleEnemyDeath;
    }

    public void Tick()
    {

    }

    public void DropLoot(Enemy enemy)
    {
        var __lootList = enemy.Loot.GetLootList();
        foreach (var loot in __lootList)
        {
            var chance = Random.Range(0, 100);
            if (chance <= loot.probability)
            {
                var __quantity = Random.Range(loot.minQuanitity, loot.maxQuantity + 1);
                var __item = loot.lootItem;
                __item.SetQuantity(__quantity);
                var __drop = Instantiate(_lootDrop, enemy.transform.position, Quaternion.identity);
                __drop.Item = __item;
                __drop.Drop();
            }
        }
    }



    private void HandleEnemyDeath(Enemy enemy)
    {
        DropLoot(enemy);
    }
}
