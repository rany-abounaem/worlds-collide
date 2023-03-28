using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> _enemies;

    private void Start()
    {
        foreach (var __enemy in _enemies)
        {
            __enemy.Setup();
        }
    }

    private void Update()
    {
        foreach (var __enemy in _enemies)
        {
            __enemy.Tick();
        }
    }
}
