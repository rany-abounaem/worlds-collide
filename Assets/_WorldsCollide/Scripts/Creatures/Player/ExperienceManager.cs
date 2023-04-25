using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _expParticlePrefab;
    [SerializeField]
    private GameObject _levelUpEffectPrefab;

    private Player _player;

    public void Setup(Player player, EnemiesManager enemiesManager)
    {
        _player = player;
        ((PlayerStatsComponent)_player.Stats).OnLevelUpdated += SpawnLevelUpEffect;
        enemiesManager.OnEnemyDeath += AddExperience;
    }

    private void AddExperience(Enemy enemy)
    {
        ((PlayerStatsComponent)_player.Stats).AddExperiencePoints(enemy.GetExperienceDrop());
        var __expParticlePrefab = Instantiate(_expParticlePrefab, enemy.transform.position, Quaternion.identity);
        var __experienceParticles = __expParticlePrefab.GetComponent<ExperienceParticles>();
        __experienceParticles.Setup(_player.transform);

    }

    private void SpawnLevelUpEffect(int level)
    {
        Instantiate(_levelUpEffectPrefab, _player.transform);
    }
}
