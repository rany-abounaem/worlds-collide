using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    private Player _player;
    private InputActions _input;

    private void ListenForControls()
    {
        _input.Game.Movement.performed += callback => _player.Movement.SetMovement(callback.ReadValue<float>());
        _input.Game.Movement.canceled += callback => _player.Movement.SetMovement(0);
        _input.Game.Jump.performed += _ => _player.Movement.Jump();
        _input.Game.Roll.performed += _ => _player.Movement.Roll();

        _input.Game.Pickup.performed += _ => _player.Interaction.Interact();

        _input.Game.Attack_1.performed += _ => _player.Ability.UseAbility("Thrust");
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
