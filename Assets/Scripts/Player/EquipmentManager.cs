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
        ItemType type = item.GetItemType();
        switch (type)
        {
            case ItemType.Hood:
                //InventoryManager.instance.inventory.Add(item);
                if (!hood.GetItemName().Equals(""))
                {
                    InventoryManager.instance.AddToInventory(hood);
                    Debug.Log("Hood detected");
                }
                hood = item;
                InventoryManager.instance.RemoveFromInventory(item);
                hoodSR.SetCategoryAndLabel("Hood", item.GetItemSpriteId().ToString());
                break;
            case ItemType.Shoulder:
                //InventoryManager.instance.inventory.Add(item);
                if(!shoulder.GetItemName().Equals(""))
                { 
                    InventoryManager.instance.AddToInventory(shoulder);
                    Debug.Log("Shoulder detected");
                }
                shoulder = item;
                InventoryManager.instance.RemoveFromInventory(item);
                leftShoulderSR.SetCategoryAndLabel("L_Shoulder", item.GetItemSpriteId().ToString());
                rightShoulderSR.SetCategoryAndLabel("R_Shoulder", item.GetItemSpriteId().ToString());
                break;
            case ItemType.Torso:
                if(!torso.GetItemName().Equals(""))
                { 
                    InventoryManager.instance.AddToInventory(torso);
                    Debug.Log("Torso detected");
                }
                torso = item;
                InventoryManager.instance.RemoveFromInventory(item);
                torsoSR.SetCategoryAndLabel("Torso", item.GetItemSpriteId().ToString());
                break;
            case ItemType.Pelvis:
                if(!pelvis.GetItemName().Equals(""))
                { 
                    InventoryManager.instance.AddToInventory(pelvis);
                    Debug.Log("Pelvis detected");
                }
                pelvis = item;
                InventoryManager.instance.RemoveFromInventory(item);
                pelvisSR.SetCategoryAndLabel("Pelvis", item.GetItemSpriteId().ToString());
                break;
            case ItemType.Boot:
                if (!boot.GetItemName().Equals(""))
                { 
                    InventoryManager.instance.AddToInventory(boot);
                    Debug.Log("Boot detected");
                }
                boot = item;
                InventoryManager.instance.RemoveFromInventory(item);
                leftBootSR.SetCategoryAndLabel("L_Boot", item.GetItemSpriteId().ToString());
                rightBootSR.SetCategoryAndLabel("R_Boot", item.GetItemSpriteId().ToString());
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
        ItemType type = item.GetItemType();
        switch (type)
        {
            case ItemType.Weapon:
                if (Weapon != null)
                    InventoryManager.instance.AddToInventory(Weapon);
                Weapon = item;
                InventoryManager.instance.RemoveFromInventory(item);
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
