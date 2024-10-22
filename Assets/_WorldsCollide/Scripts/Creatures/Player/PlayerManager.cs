using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{

    private Player _player;
    private InputActions _input;

    private void ListenForControls()
    {
        _input.Game.Movement.performed += callback => _player.Movement.SetMovementInput(callback.ReadValue<float>());
        _input.Game.Movement.canceled += callback => _player.Movement.SetMovementInput(0);
        _input.Game.Jump.performed += _ => _player.Movement.Jump();
        _input.Game.Roll.performed += _ => _player.Movement.Roll();

        _input.Game.Pickup.performed += _ => _player.Interaction.Interact();
    }

    public void Setup(InputActions inputActions, Player player)
    {
        _player = player;
        _input = inputActions;
        ListenForControls();
    }

    public void Tick(float deltaTime)
    {

    }
}
