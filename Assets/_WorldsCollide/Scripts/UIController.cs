using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WorldsCollide.Input;

public class UIController : MonoBehaviour
{
    public Slider playerHPSlider;
    public Image playerHPFill;
    public Gradient HPGradient;

    [SerializeField]
    RectTransform _inventoryPanel;

    private InputActions _input;
    private Player _player;
    
    public void Setup(InputActions input, Player player)
    {
        _input = input;
        _player = player;

        if (playerHPSlider && playerHPFill)
            UpdateUIHealth();

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

    public void UpdateUIHealth()
    {
        playerHPSlider.value = StatsComponent.instance.Health / StatsComponent.instance.MaxHealth;
        playerHPFill.color = HPGradient.Evaluate(StatsComponent.instance.Health / StatsComponent.instance.MaxHealth);
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
