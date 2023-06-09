using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public delegate void FloatingTextCallback(FloatingText text);

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _textPopupPrefab;
    [SerializeField]
    private FloatingTextChannel _floatingTextChannel;

    private List<FloatingText> _floatingTexts = new List<FloatingText>();

    public void Setup()
    {
        _floatingTextChannel.OnFloatingTextPopup += InstantiateFloatingText;
    }

    public void Tick()
    {

    }

    private void InstantiateFloatingText(Vector3 pos, string text, Color color)
    {
        var __floatingTextPrefab = Instantiate(_textPopupPrefab, pos, Quaternion.identity, transform);
        var __floatingTextComponent = __floatingTextPrefab.GetComponent<FloatingText>();
        __floatingTextComponent.Setup(text, color, 2f, 1f, 100f);
        _floatingTexts.Add(__floatingTextComponent);
        __floatingTextComponent.OnTimeEnd += DestroyFloatingText;
    }
    
    private void DestroyFloatingText(FloatingText floatingText)
    {
        FloatingText __textToRemove = null;
        foreach (var __floatingText in _floatingTexts)
        {
            if (__floatingText == floatingText)
            {
                __textToRemove = __floatingText;
                break;
            }
        }
        if (__textToRemove != null)
        {
            Destroy(__textToRemove.gameObject);
            _floatingTexts.Remove(__textToRemove);
        }
        
    }
}
