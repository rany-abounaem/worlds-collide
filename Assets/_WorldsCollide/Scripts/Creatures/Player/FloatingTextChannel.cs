using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public delegate void TextCallback(Vector3 pos, string text, Color color);
[CreateAssetMenu(fileName = "FloatingTextChannel", menuName = "ScriptableObjects/UI/FloatingTextChannel")]
public class FloatingTextChannel : ScriptableObject
{
    public event TextCallback OnFloatingTextPopup;

    public void Raise(Vector3 pos, string text, Color color)
    {
        OnFloatingTextPopup?.Invoke(pos, text, color);
    }
}
