using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DetectionCallback();
public class DetectionArea : MonoBehaviour
{
    public event DetectionCallback OnDetection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            OnDetection?.Invoke();
        }
    }
}
