using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ActionsMenuUI : PaginatedUIPanel
{
    [SerializeField]
    private RectTransform _slotsParent;

    private AbilityComponent _abilities;
    private List<ActionsMenuSlotUI> _slots;

    private InputActions _input;

    private Image _dragImage;
    private Ability _currentlyDragging;

    public override void Setup(Player player)
    {
        base.Setup(player);
        _abilities = player.Ability;
        _slots = _slotsParent.GetComponentsInChildren<ActionsMenuSlotUI>().ToList();
    }

    protected override void RefreshPage()
    {
        base.RefreshPage();
        var __slotsCount = _slots.Count;
        var __paginatedAbilities = _abilities.GetAbilities((_pageIndex - 1) * __slotsCount, __slotsCount);
        var __paginatedAbilitiesCount = __paginatedAbilities.Count;
        for (var i = 0; i < __slotsCount; i++)
        {
            Debug.Log(i);
            if (i > __paginatedAbilitiesCount - 1)
            {
                _slots[i].UpdateSlot(null);
                continue;
            }
            _slots[i].UpdateSlot(__paginatedAbilities[i]);
        }
    }

    public void ActionMenuDrag()
    {
        var __results = new List<RaycastResult>();
        var __eventSystem = EventSystem.current;
        var __pointerEventData = new PointerEventData(__eventSystem);
        __pointerEventData.position = Mouse.current.position.ReadValue();
        __eventSystem.RaycastAll(__pointerEventData, __results);
        foreach (var __result in __results)
        {
            if (__result.gameObject.TryGetComponent(out ActionsMenuSlotUI __menuSlot) && __menuSlot.GetAbility()!= null)
            {
                _dragImage = Instantiate(__menuSlot.GetImage(), __menuSlot.transform);
                var __imageColor = _dragImage.color;
                __imageColor.a = 0.75f;
                _dragImage.color = __imageColor;
                _currentlyDragging = __menuSlot.GetAbility();
                break;
            }
        }
    }

    public void ActionMenuToBarDrop()
    {
        if (_currentlyDragging!=null)
        {
            var __results = new List<RaycastResult>();
            var __eventSystem = EventSystem.current;
            var __pointerEventData = new PointerEventData(__eventSystem);
            __pointerEventData.position = Mouse.current.position.ReadValue();
            __eventSystem.RaycastAll(__pointerEventData, __results);
            foreach (var __result in __results)
            {
                if (__result.gameObject.TryGetComponent(out ActionsBarSlotUI __barSlot))
                {
                    __barSlot.UpdateSlot(_currentlyDragging);
                    break;
                }
            }
            Destroy(_dragImage.gameObject);
            _currentlyDragging = null;
            _dragImage = null;
        }
        
    }

    private void Update()
    {
        if (_dragImage != null)
        {
            _dragImage.transform.position = Mouse.current.position.ReadValue();
        }
    }
}
