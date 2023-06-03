using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyDeathCallback (Enemy creature);

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    List<Enemy> _enemies;

    public event EnemyDeathCallback OnEnemyDeath;


    public void Setup()
    {
        foreach(var __enemy in _enemies)
        {
            __enemy.Setup();
            __enemy.OnDeath += ()=> { HandleEnemyDeath(__enemy); };
        }
    }

    public void Tick()
    {
        foreach (var __enemy in _enemies)
        {
            __enemy.Tick();
        }
    }

    public void Destroy()
    {

    }

    private void HandleEnemyDeath(Enemy enemy)
    {
        OnEnemyDeath?.Invoke(enemy);
        StartCoroutine(DeactivateEnemy(enemy));
    }

    private IEnumerator DeactivateEnemy (Enemy enemy)
    {
        yield return new WaitForSeconds(2f);
        enemy.gameObject.SetActive(false);
    }
}
