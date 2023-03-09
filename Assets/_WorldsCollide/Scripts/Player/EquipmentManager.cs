using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

public class EquipmentManager : MonoBehaviour
{

    public static EquipmentManager instance;

    [SerializeField]
    //Item leftShoulder, leftElbow, leftWrist, leftLeg, leftBoot, leftWeapon, rightShoulder,
    //    rightElbow, rightWrist, rightLeg, rightBoot, rightWeapon, hood, face, torso, pelvis;
    Item shoulder, elbow, wrist, leg, boot, hood, face, torso, pelvis;
    [field: SerializeField]
    public Weapon Weapon { get; set; }

    [SerializeField]
    SpriteResolver hoodSR, leftShoulderSR, rightShoulderSR, leftWeaponSR, rightWeaponSR, leftBootSR, rightBootSR, torsoSR, pelvisSR;

    public UnityEvent onEquipmentChanged;

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

    public void Equip(Armor item)
    {
        //Debug.Log(item.type.ToString());
        ItemType type = item.Type;
        switch (type)
        {
            case ItemType.Hood:
                //InventoryManager.instance.inventory.Add(item);
                if (!hood.ItemName.Equals(""))
                {
                    InventoryManager.instance.AddItem(hood);
                    Debug.Log("Hood detected");
                }
                hood = item;
                InventoryManager.instance.RemoveItem(item);
                hoodSR.SetCategoryAndLabel("Hood", item.SpriteId.ToString());
                break;
            case ItemType.Shoulder:
                //InventoryManager.instance.inventory.Add(item);
                if(!shoulder.ItemName.Equals(""))
                { 
                    InventoryManager.instance.AddItem(shoulder);
                    Debug.Log("Shoulder detected");
                }
                shoulder = item;
                InventoryManager.instance.RemoveItem(item);
                leftShoulderSR.SetCategoryAndLabel("L_Shoulder", item.SpriteId.ToString());
                rightShoulderSR.SetCategoryAndLabel("R_Shoulder", item.SpriteId.ToString());
                break;
            case ItemType.Torso:
                if(!torso.ItemName.Equals(""))
                { 
                    InventoryManager.instance.AddItem(torso);
                    Debug.Log("Torso detected");
                }
                torso = item;
                InventoryManager.instance.RemoveItem(item);
                torsoSR.SetCategoryAndLabel("Torso", item.SpriteId.ToString());
                break;
            case ItemType.Pelvis:
                if(!pelvis.ItemName.Equals(""))
                { 
                    InventoryManager.instance.AddItem(pelvis);
                    Debug.Log("Pelvis detected");
                }
                pelvis = item;
                InventoryManager.instance.RemoveItem(item);
                pelvisSR.SetCategoryAndLabel("Pelvis", item.SpriteId.ToString());
                break;
            case ItemType.Boot:
                if (!boot.ItemName.Equals(""))
                { 
                    InventoryManager.instance.AddItem(boot);
                    Debug.Log("Boot detected");
                }
                boot = item;
                InventoryManager.instance.RemoveItem(item);
                leftBootSR.SetCategoryAndLabel("L_Boot", item.SpriteId.ToString());
                rightBootSR.SetCategoryAndLabel("R_Boot", item.SpriteId.ToString());
                break;
            default:
                Debug.Log("Item has no type");
                break;


        }
        PlayerStats.instance.UpdatePlayerStatsOnEquip(item);
        onEquipmentChanged.Invoke();
            

    }

    public void Equip(Weapon item)
    {
        ItemType type = item.Type;
        switch (type)
        {
            case ItemType.Weapon:
                if (Weapon != null)
                    InventoryManager.instance.AddItem(Weapon);
                Weapon = item;
                InventoryManager.instance.RemoveItem(item);
                break;
            default:
                Debug.Log("Item has no type");
                break;


        }
        PlayerStats.instance.UpdatePlayerStatsOnEquip(item);
        onEquipmentChanged.Invoke();
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
