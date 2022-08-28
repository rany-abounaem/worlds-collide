using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHPSlider;
    public Image playerHPFill;
    public Gradient HPGradient;
    
    void Start()
    {
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
}
