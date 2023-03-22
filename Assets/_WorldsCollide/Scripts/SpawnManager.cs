using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Creature> _creatures;
    private void Start()
    {
        foreach (var __creature in _creatures)
        {
            __creature.Setup();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (var __creature in _creatures)
        {
            __creature.Tick();
        }
    }
}
