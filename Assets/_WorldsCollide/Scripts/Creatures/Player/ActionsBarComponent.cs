using System.Collections.Generic;
using UnityEngine;

public class ActionsBarComponent : MonoBehaviour
{
    private AbilityComponent _playerAbilities;
    private List<Ability> _equippedAbilities;

    public void Setup(AbilityComponent abilities)
    {
        _playerAbilities = abilities;
    }

    public void EquipAbility(Ability ability)
    {

    }
}
