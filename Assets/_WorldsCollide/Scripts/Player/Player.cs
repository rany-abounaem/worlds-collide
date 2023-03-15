using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldsCollide.Interaction;

public class Player : Creature
{
    public InteractionComponent Interaction { get; private set; }
    public InventoryComponent Inventory { get; private set; }

    public override void Setup()
    {
        base.Setup();
        Interaction = GetComponent<InteractionComponent>();
        Inventory = GetComponent<InventoryComponent>();
    }
}
