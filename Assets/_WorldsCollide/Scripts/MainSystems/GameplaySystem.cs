using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameplaySystem : MonoBehaviour
{

    public static GameplaySystem instance;

    public GameObject BloodEffect;
    public GameObject DamagePopup;


    // NEW GAMEPLAY SYSTEM STARTS HERE //
    //[SerializeField]
    //CharacterPickSystem _characterPickSystem;

    [SerializeField]
    private Player _player;
    [SerializeField]
    private UIManager _UIManager;
    [SerializeField]
    private PlayerManager _playerController;
    [SerializeField]
    private EnemiesManager _enemiesManager;
    [SerializeField]
    private LootingManager _lootingManager;
    [SerializeField]
    private ExperienceManager _experienceManager;


    private InputActions _inputActions;


    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        _player.Setup();

        _inputActions = new InputActions();
        _inputActions.Enable();

        _playerController.Setup(_inputActions, _player);
        _enemiesManager.Setup();
        _lootingManager.Setup(_enemiesManager);
        _experienceManager.Setup(_player, _enemiesManager);
        _UIManager.Setup(_inputActions, _player);

    }

    private void Update()
    {
        _enemiesManager.Tick();
    }
}


