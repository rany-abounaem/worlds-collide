using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldsCollide.Interaction;

public enum PlayerClass {Rogue, Archer, Magician, Healer, Warrior}

public class Player : Creature
{
    public InteractionComponent Interaction { get; private set; }
    public InventoryComponent Inventory { get; private set; }
    public EquipmentComponent Equipment { get; private set; }

    public override void Setup()
    {
        base.Setup();
        Interaction = GetComponent<InteractionComponent>();
        Inventory = GetComponent<InventoryComponent>();
    }
}
