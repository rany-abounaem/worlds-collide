using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TooltipUI : UIPanel
{
    [SerializeField]
    private GameObject _tooltipPanel;
    [SerializeField]
    private TextMeshProUGUI _textComponent;
    [SerializeField]
    private TooltipChannel _tooltipChannel;

    private Coroutine _tooltipCoroutine;

    private GameObject _tooltipRaiser;

    public override void Setup(Player player)
    {
        _tooltipChannel.OnTooltipRequest += (r, s) =>
        {
            if (_tooltipCoroutine != null)
            {
                StopCoroutine(_tooltipCoroutine);
            }
            _tooltipCoroutine = StartCoroutine(ShowTooltip(r, s));
        };

        _tooltipChannel.OnTooltipCancel += (c) =>
        {
            HideTooltip(c);
        };
    }

    private IEnumerator ShowTooltip(GameObject r, string s)
    {
        _tooltipRaiser = r;
        _textComponent.text = s;
        _tooltipPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        _tooltipPanel.SetActive(false);
        _tooltipRaiser = null;
    }

    private void HideTooltip(GameObject c)
    {
        if (_tooltipRaiser == c && _tooltipCoroutine != null)
        {
            StopCoroutine(_tooltipCoroutine);
            _tooltipCoroutine = null;
            _tooltipRaiser = null;
            _tooltipPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (_tooltipPanel.activeSelf)
        {
            var __mousePos = Mouse.current.position.ReadValue();
            var __tooltipPanelRect = (RectTransform)_tooltipPanel.transform;
            _tooltipPanel.transform.position = new Vector2 (__mousePos.x + __tooltipPanelRect.rect.width/2, __mousePos.y + __tooltipPanelRect.rect.height / 2);
        }
    }
}
