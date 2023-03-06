using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHPSlider;
    public Image playerHPFill;
    public Gradient HPGradient;

    [SerializeField]
    RectTransform _inventoryPanel;
    
    void Start()
    {
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
