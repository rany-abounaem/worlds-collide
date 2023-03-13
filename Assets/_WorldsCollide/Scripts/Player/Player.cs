using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldsCollide.Interaction;

public class Player : Creature
{
    public InteractionComponent Interaction { get; private set; }

    private void Update()
    {
        Interaction = GetComponent<InteractionComponent>();
    }
}
