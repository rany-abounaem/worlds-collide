using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PaginatedUIPanel : UIPanel
{
    [SerializeField]
    private Button _previousPage;
    [SerializeField]
    private Button _nextPage;
    [SerializeField]
    private TextMeshProUGUI _pageIndexText;

    [SerializeField]
    private int _maxPageIndex;
    protected int _pageIndex;

    public override void Setup(Player player)
    {
        base.Setup(player);
        _pageIndex = 1;
        _previousPage.onClick.AddListener(() =>
        {
            PreviousPage();
        });
        _nextPage.onClick.AddListener(() =>
        {
            NextPage();
        });
    }

    public void NextPage()
    {
        if (_pageIndex == _maxPageIndex)
        {
            return;
        }
        _pageIndex++;
        RefreshPage();
    }

    public void PreviousPage()
    {
        if (_pageIndex == 1)
        {
            return;
        }
        _pageIndex--;
        RefreshPage();
    }


    public void SetPageMaximumIndex()
    {
        _maxPageIndex = _pageIndex;
    }

    protected override void RefreshPage()
    {
        base.RefreshPage();
        _pageIndexText.text = _pageIndex.ToString();
    }
}
