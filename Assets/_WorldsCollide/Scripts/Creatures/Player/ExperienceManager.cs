using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _expParticlePrefab;

    private Player _player;
    private float _experience;

    public void Setup(Player player, EnemiesManager enemiesManager)
    {
        _player = player;
        enemiesManager.OnEnemyDeath += AddExperience;
    }

    private void AddExperience(Enemy enemy)
    {
        _experience += enemy.GetExperienceDrop();
        Instantiate(_expParticlePrefab, _player.transform).GetComponent<ParticleSystem>().Play();
    }
}
