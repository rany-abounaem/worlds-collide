using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextRaiser : MonoBehaviour
{
    [SerializeField]
    private FloatingTextChannel _channel;

    public void SpawnFloatingText(Vector3 pos, string text, Color color)
    {
        _channel.Raise(pos, text, color);
    }
}
