using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CharacterPickCallback(Player PlayerComponent);

public class CharacterPickSystem : MonoBehaviour
{
    // Dummy player prefab for now. Will be removed and picked player will fetch saved data and passed to this system
    [SerializeField]
    Player _player;

    public event CharacterPickCallback OnCharacterPick;
    private void Awake()
    {
        OnCharacterPick.Invoke(_player);
    }
}
