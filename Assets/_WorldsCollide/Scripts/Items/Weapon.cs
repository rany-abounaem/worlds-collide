using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Hitbox
{
    public Vector2 center;
    public Vector2 size;
}

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Items/Weapon")]
public class Weapon : Item
{

    [SerializeField]
    private Hitbox _hitbox;
    
    public int AttackPower { get; set; }

    public Hitbox GetHitbox() 
    {
        return _hitbox; 
    }

}
