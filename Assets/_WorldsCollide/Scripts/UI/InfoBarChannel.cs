using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StringCallback(string str);

[CreateAssetMenu(fileName = "InfoBarChannel", menuName = "ScriptableObjects/UI/InfoBar")]
public class InfoBarChannel : ScriptableObject
{
    public event StringCallback OnInfoBarRaised;

    public void Raise(string text)
    {
        OnInfoBarRaised?.Invoke(text);
    }
}
