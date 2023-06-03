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
    private FloatingTextRaiser _floatingTextRaiser;

    public void Setup(Player player, EnemiesManager enemiesManager)
    {
        _player = player;
        ((PlayerStatsComponent)_player.Stats).OnLevelUpdated += SpawnLevelUpEffect;
        enemiesManager.OnEnemyDeath += AddExperience;
        _floatingTextRaiser = GetComponent<FloatingTextRaiser>();
    }

    private void AddExperience(Enemy enemy)
    {
        var __experiencePoints = enemy.GetExperienceDrop();
        ((PlayerStatsComponent)_player.Stats).AddExperiencePoints(__experiencePoints);
        var __expParticlePrefab = Instantiate(_expParticlePrefab, enemy.transform.position, Quaternion.identity);
        var __experienceParticles = __expParticlePrefab.GetComponent<ExperienceParticles>();
        __experienceParticles.Setup(_player.transform);
        _floatingTextRaiser.SpawnFloatingText(_player.transform.position, __experiencePoints.ToString(), Color.white);

    }

    private void SpawnLevelUpEffect(int level)
    {
        Instantiate(_levelUpEffectPrefab, _player.transform);
    }
}
