using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject BloodEffect;
    public GameObject ExpGainEffect;

    public GameObject DamagePopup;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    void Start()
    {
        Weapon x = ScriptableObject.CreateInstance<Weapon>(); /*{ ItemName = "Dagger", Type = ItemType.Weapon, AttackPower = 1, Cost = 50, SpriteId = 2};*/
        x.AttackPower = 10;
        x.Type = ItemType.Weapon;
        InventoryManager.instance.AddToInventory(x);
        //InventoryManager.instance.AddToInventory(Weapon.CreateInstance("Dagger", 1, 50, ItemType.Weapon, null, 2));
        //InventoryManager.instance.AddToInventory(new Armor("Shoulder", 1, 20, ItemType.Shoulder, null, 1));
        //InventoryManager.instance.AddToInventory(new Armor("Torso", 1, 20, ItemType.Torso, null, 1));
        //InventoryManager.instance.AddToInventory(new Armor("Pelvis", 1, 20, ItemType.Pelvis, null, 1));
        //InventoryManager.instance.AddToInventory(new Armor("Boot", 1, 20, ItemType.Boot, null, 1));
        //InventoryManager.instance.AddToInventory(new Armor("Hood", 1, 20, ItemType.Hood, null, 1));
        EquipmentManager.instance.Equip((Weapon)InventoryManager.instance.GetItemFromInventory(0));
        //EquipmentManager.instance.Equip((Armor)InventoryManager.instance.GetItemFromInventory(0));
        //EquipmentManager.instance.Equip((Armor)InventoryManager.instance.GetItemFromInventory(0));
        //EquipmentManager.instance.Equip((Armor)InventoryManager.instance.GetItemFromInventory(0));
        //EquipmentManager.instance.Equip((Armor)InventoryManager.instance.GetItemFromInventory(0));
        //EquipmentManager.instance.Equip((Armor)InventoryManager.instance.GetItemFromInventory(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
