using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    RectTransform _inventoryPanel;
    [SerializeField]
    HealthUI _healthUI;

    private InputActions _input;
    private Player _player;
    
    public void Setup(InputActions input, Player player)
    {
        _input = input;
        _player = player;
        _healthUI.Setup(player);

        Debug.Log("Player " + player + "Stats " + player.Stats);
        //_player.Stats.onHealthUpdate.AddListener(() => UpdateUIHealth());

        _input.UI.OpenInventory.performed += _ => ToggleInventory();
    }

    private void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        var _inventoryUI = _inventoryPanel.gameObject;
        _inventoryUI.SetActive(!_inventoryUI.activeSelf);
        if (_inventoryUI.activeSelf)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
