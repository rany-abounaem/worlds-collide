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
        var __expParticlePrefab = Instantiate(_expParticlePrefab, enemy.transform.position, Quaternion.identity);
        var __experienceParticles = __expParticlePrefab.GetComponent<ExperienceParticles>();
        __experienceParticles.Setup(_player.transform);

    }
}
