using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameplaySystem : MonoBehaviour
{

    public static GameplaySystem instance;

    public GameObject BloodEffect;
    public GameObject ExpGainEffect;

    public GameObject DamagePopup;


    // NEW GAMEPLAY SYSTEM STARTS HERE //
    //[SerializeField]
    //CharacterPickSystem _characterPickSystem;

    [SerializeField]
    private Player _player;
    [SerializeField]
    private UIController _UIManager;
    [SerializeField]
    private PlayerController _playerController;

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
        _UIManager.Setup(_inputActions, _player);


    }
}


