using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActionsBarUI : UIPanel
{
    private List<ActionsBarSlotUI> _actionSlots;
    private Player _player;
    private Image _dragImage;
    private Ability _currentlyDragging;
    public override void Setup(Player player)
    {
        _player = player;

        _actionSlots = GetComponentsInChildren<ActionsBarSlotUI>().ToList();

        for (var __i = 0; __i < _actionSlots.Count; __i++)
        {
            _actionSlots[__i].SetSlotIndex(__i);
            _actionSlots[__i].OnSlotClick += UseActionSlot;
        }
    }

    public void UseActionSlot(int index)
    {
        var __ability = (Ability)_actionSlots[index].GetSlottable();
        if (__ability != null)
        {
            _player.Ability.UseAbility(__ability.GetName());
        }
        
    }

    public void ActionBarDrag()
    {
        var __results = new List<RaycastResult>();
        var __eventSystem = EventSystem.current;
        var __pointerEventData = new PointerEventData(__eventSystem);
        __pointerEventData.position = Mouse.current.position.ReadValue();
        __eventSystem.RaycastAll(__pointerEventData, __results);
        foreach (var __result in __results)
        {
            if (__result.gameObject.TryGetComponent(out ActionsBarSlotUI __barSlot) && __barSlot.GetSlottable() != null)
            {
                _dragImage = Instantiate(__barSlot.GetImage(), __barSlot.transform);
                var __imageColor = _dragImage.color;
                __imageColor.a = 0.75f;
                _dragImage.color = __imageColor;
                _currentlyDragging = (Ability)__barSlot.GetSlottable();
                __barSlot.UpdateSlot(null);
                break;
            }
        }
    }

    public void ActionBarDrop()
    {
        if (_dragImage != null)
        {
            var __results = new List<RaycastResult>();
            var __eventSystem = EventSystem.current;
            var __pointerEventData = new PointerEventData(__eventSystem);
            __pointerEventData.position = Mouse.current.position.ReadValue();
            __eventSystem.RaycastAll(__pointerEventData, __results);
            foreach (var __result in __results)
            {
                var __resultGameObject = __result.gameObject;
                if (__resultGameObject.TryGetComponent(out ActionsBarSlotUI __barSlot))
                {
                    __barSlot.UpdateSlot(_currentlyDragging);
                    break;
                }
            }
            Destroy(_dragImage.gameObject);
            _dragImage = null;
            _currentlyDragging = null;
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
