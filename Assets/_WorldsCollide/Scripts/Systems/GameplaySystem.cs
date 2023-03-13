using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameplaySystem : MonoBehaviour
{

    public static GameplaySystem instance;

    public GameObject BloodEffect;
    public GameObject ExpGainEffect;

    public GameObject DamagePopup;


    // NEW GAMEPLAY SYSTEM STARTS HERE //
    //[SerializeField]
    //CharacterPickSystem _characterPickSystem;

    [SerializeField]
    Player _player;
    [SerializeField]
    PlayerController _playerController;


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

        //_characterPickSystem.OnCharacterPick += _playerController.Setup;
        _playerController.Setup(_player);
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


