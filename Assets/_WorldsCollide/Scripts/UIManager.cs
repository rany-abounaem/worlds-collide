using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WorldsCollide.Input;

public class UIManager : MonoBehaviour
{
    public Slider playerHPSlider;
    public Image playerHPFill;
    public Gradient HPGradient;

    [SerializeField]
    RectTransform _inventoryPanel;

    [SerializeField]
    InputManager _inputManager;
    
    void Start()
    {
        _inputManager.InputActions.UI.OpenInventory.performed += _ => ToggleInventory();
        if (playerHPSlider && playerHPFill)
            UpdateUIHealth();
        PlayerStats.instance.onHealthUpdate.AddListener(() => UpdateUIHealth());
    }
    
    void Update()
    {
        
    }

    public void UpdateUIHealth()
    {
        playerHPSlider.value = PlayerStats.instance.Health / PlayerStats.instance.MaxHealth;
        playerHPFill.color = HPGradient.Evaluate(PlayerStats.instance.Health / PlayerStats.instance.MaxHealth);
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
