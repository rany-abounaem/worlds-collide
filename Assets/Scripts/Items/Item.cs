using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//public enum ItemType {
//    L_Shoulder, R_Shoulder, L_Elbow, R_Elbow, L_Wrist, R_Wrist, L_Leg,
//    R_Leg, L_Boot, R_Boot, L_Weapon, R_Weapon, Hood, Face, Head, Torso, Pelvis }
public enum ItemType
{
    Shoulder, Elbow, Wrist, Leg, Boot, Weapon, Hood, Face, Head, Torso, Pelvis, Consumable, Quest
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item", order = 1)]
[Serializable]
public class Item : ScriptableObject
{
    [SerializeField]
    string itemName;
    [SerializeField]
    int spriteId, quantity, cost, durability;
    [SerializeField]
    ItemType type;
    [SerializeField]
    List <Action> actions;
    //Buff[] buffs;

    public Item(string name, int spriteId, int cost, ItemType type, List <Action> actions)
    {
        this.itemName = name;
        this.spriteId = spriteId;
        quantity= 1;
        this.cost = cost;
        this.type = type;
        durability = 100;
        this.actions = actions;
    }

    public ItemType GetItemType()
    {
        return type;
    }

    public string GetItemName()
    {
        return name;
    }

    public int GetItemSpriteId()
    {
        return spriteId;
    }
}

