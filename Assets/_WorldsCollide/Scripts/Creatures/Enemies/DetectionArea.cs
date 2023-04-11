using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DetectionCallback(Creature player);
public class DetectionArea : MonoBehaviour
{
    public event DetectionCallback OnDetection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player __player))
        {
            Debug.Log("Player detected");
            OnDetection?.Invoke(__player);
        }
    }
}
