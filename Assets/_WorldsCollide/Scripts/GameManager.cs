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
        Weapon x = ScriptableObject.CreateInstance<Weapon>();
        x.AttackPower = 10;
        x.Type = ItemType.Weapon;
        InventoryManager.instance.AddItem(x);
        EquipmentManager.instance.Equip((Weapon)InventoryManager.instance.GetItem(0));
    }

    // Update is called once per frame
    void Update()
    {

    }
}


