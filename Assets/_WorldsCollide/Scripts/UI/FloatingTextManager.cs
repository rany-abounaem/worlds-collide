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
        UpdateFloatingTexts();
    }

    private void UpdateFloatingTexts()
    {
        foreach(var __floatingText in _floatingTexts)
        {
            __floatingText.Tick();
        }
    }

    private void InstantiateFloatingText(Vector3 pos, string text, Color color)
    {
        var __floatingTextPrefab = Instantiate(_textPopupPrefab, pos, Quaternion.identity, transform);
        var __floatingTextComponent = __floatingTextPrefab.GetComponent<FloatingText>();
        __floatingTextComponent.Setup(text, color, 10f, 1f, 1f);
        _floatingTexts.Add(__floatingTextComponent);
        __floatingTextComponent.OnTimeEnd += DestroyFloatingText;
    }
    
    private void DestroyFloatingText(FloatingText floatingText)
    {

        foreach (var __floatingText in _floatingTexts)
        {
            if (__floatingText == floatingText)
            {
                Destroy(__floatingText.gameObject);
                _floatingTexts.Remove(floatingText);
                break;
            }
        }
    }
}
