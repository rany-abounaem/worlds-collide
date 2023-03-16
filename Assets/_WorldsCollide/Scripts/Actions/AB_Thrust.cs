using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability_Thrust", menuName = "ScriptableObjects/Abilities/Rogue/Thrust")]
public class AB_Thrust : PlayerAbility
{

    public AB_Thrust(GameObject caster): base(caster)
    {

    }

    override public void Use()
    {
        Debug.Log("Used AB_Thrust");
    }


}
