using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    HealthUI _healthUI;
    [SerializeField]
    InventoryUI _inventoryUI;

    private InputActions _input;
    private Player _player;
    
    public void Setup(InputActions input, Player player)
    {
        _input = input;
        _player = player;
        _healthUI.Setup(player);
        _inventoryUI.Setup(player.Inventory);

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
        var __inventoryUI = _inventoryUI.gameObject;
        __inventoryUI.gameObject.SetActive(!__inventoryUI.activeSelf);
        if (__inventoryUI.activeSelf)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
