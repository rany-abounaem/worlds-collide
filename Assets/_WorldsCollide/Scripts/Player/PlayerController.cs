using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private InputActions _input;

    public void Setup(Player player)
    {
        _player = player;
        InitializeInput();
        ListenForControls();
    }

    private void InitializeInput()
    {
        _input = new InputActions();
        _input.Enable();
    }

    public void Tick(float deltaTime)
    {

    }

    private void ListenForControls()
    {
        _input.Game.Movement.performed += callback => _player.Movement.SetMovement(callback.ReadValue<float>());
        _input.Game.Movement.canceled += callback => _player.Movement.SetMovement(0);
        _input.Game.Jump.performed += _ => _player.Movement.Jump();
        _input.Game.Roll.performed += _ => _player.Movement.Roll();
        _input.Game.Pickup.performed += _ => _player.Interaction.Interact();
    }
}
