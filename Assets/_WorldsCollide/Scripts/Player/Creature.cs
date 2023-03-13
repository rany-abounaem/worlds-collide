using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public MovementComponent Movement { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<MovementComponent>();
    }

}
