using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    List<UIPanel> _panels;

    private UIPanel _currentActivePanel;

    private InputActions _input;
    private Player _player;
    
    public void Setup(InputActions input, Player player)
    {
        _input = input;
        _player = player;

        foreach (var __panel in _panels)
        {
            __panel.Setup(player);

            if (__panel is InventoryUI)
            {
                _input.UI.Inventory.performed += _ => ToggleUIPanel(__panel);
            }

            if (__panel is ActionsMenuUI)
            {
                _input.UI.AbilityMenu.performed += _ => ToggleUIPanel(__panel);
            }
        }
        
    }

    private void ToggleUIPanel(UIPanel panel)
    {
        var __panelGameObject = panel.gameObject;
        if (_currentActivePanel == panel)
        {
            __panelGameObject.SetActive(false);
            _currentActivePanel = null;
        }
        else
        {
            __panelGameObject.SetActive(true);
            _currentActivePanel?.gameObject.SetActive(false);
            _currentActivePanel = panel;
        }

        if (__panelGameObject.activeSelf)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
