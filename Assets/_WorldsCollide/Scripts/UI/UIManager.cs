using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<UIPanel> _panels;

    [SerializeField]
    private FloatingTextChannel _floatingTextChannel;

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
                var __actionsMenuPanel = __panel as ActionsMenuUI;
                _input.UI.AbilityMenu.performed += _ => ToggleUIPanel(__panel);
                _input.UI.DragAndDrop.performed += _ => __actionsMenuPanel.ActionMenuDrag();
                _input.UI.DragAndDrop.canceled += _ => __actionsMenuPanel.ActionMenuToBarDrop();
            }

            if (__panel is ActionsBarUI)
            {
                var __actionsBarPanel = __panel as ActionsBarUI;
                _input.UI.ActionsBar_1.performed += _ => __actionsBarPanel.UseActionSlot(0);
                _input.UI.DragAndDrop.performed += _ => __actionsBarPanel.ActionBarDrag();
                _input.UI.DragAndDrop.canceled += _ => __actionsBarPanel.ActionBarDrop();
            }
        }

        // Add reference to textpopup manager (unrelated to UI manager)
        // Instantiate textpopup and add to list with x duration
        // Loop through textpopups list and update their scale and position
        // Delete if x duration is done
        //_floatingTextChannel.OnFloatingTextPopup += 


    }

    //private IEnumerator ShowFloatingText(string text, )
    //{
    //    yield return new WaitForSeconds(2f);
    //}

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
            _currentActivePanel?.gameObject.SetActive(false);
            _currentActivePanel = panel;
            __panelGameObject.SetActive(true);
            panel.Open();
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
