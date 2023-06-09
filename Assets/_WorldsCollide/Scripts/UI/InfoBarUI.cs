using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBarUI : UIPanel
{
    [SerializeField]
    private InfoBarChannel _infoBarChannel;
    [SerializeField]
    private TextMeshProUGUI _textComponent;

    private Coroutine _infoBarCoroutine;
    
    public override void Setup(Player player)
    {
        _infoBarChannel.OnInfoBarRaised += UpdateInfoBar;
    }

    private void UpdateInfoBar (string text)
    {
        if (_infoBarCoroutine != null)
        {
            StopCoroutine(_infoBarCoroutine);
        }
        _infoBarCoroutine = StartCoroutine(ShowInfoBar(text));
    }

    private IEnumerator ShowInfoBar(string text)
    {
        _textComponent.text = text;
        _textComponent.gameObject.SetActive(true);
        Debug.Log("ui shwo info bar");
        yield return new WaitForSeconds(1f);
        _textComponent.gameObject.SetActive(false);
    }
}
