using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

public class EquipmentComponent : MonoBehaviour
{
    public Armor Gauntlets { get; private set; }
    public Armor Pauldron { get; private set; }
    public Armor Helmet { get; private set; }
    public Armor Chest { get; private set; }
    public Armor Pads { get; private set; }
    public Armor Leggings { get; private set; }
    public Armor Boots { get; private set; }

    [SerializeField]
    private WeaponComponent _rightWeapon;

    [SerializeField]
    private SpriteResolver hoodSR;
    [SerializeField]
    private SpriteResolver leftShoulderSR;
    [SerializeField]
    private SpriteResolver rightShoulderSR;
    [SerializeField]
    private SpriteResolver leftWeaponSR;
    [SerializeField]
    private SpriteResolver rightWeaponSR;
    [SerializeField]
    private SpriteResolver leftBootSR;
    [SerializeField]
    private SpriteResolver rightBootSR;
    [SerializeField]
    private SpriteResolver torsoSR;
    [SerializeField]
    private SpriteResolver pelvisSR;

    public WeaponComponent GetLeftWeapon()
    {
        return _rightWeapon;
    }

    public UnityEvent onEquipmentChanged;

    public void Setup()
    {
        _rightWeapon.Setup();
    }

    public void Equip(Armor item)
    {

    }

    public void Equip(Weapon weapon)
    {
        _rightWeapon.SetWeapon(weapon);
    }

    public void SwapSprites()
    {
        string rightLabel = rightShoulderSR.GetLabel();
        rightLabel = rightLabel.Replace("_r_", "_l_");
        Debug.Log(rightLabel);
        string leftLabel = leftShoulderSR.GetLabel();
        leftLabel = leftLabel.Replace("_l_", "_r_");
        rightShoulderSR.SetCategoryAndLabel("R_Shoulder", leftLabel);
        leftShoulderSR.SetCategoryAndLabel("L_Shoulder", rightLabel);
    }

}
