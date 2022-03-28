using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public PlayerClass player = null;

    //Start
    void Start()
    {
        player = PlayerClass.Instance;  
    }
    
    //Update
    void Update()
    {
        int i = player.GetHealth();
        SetHealth(i);
    }
    
    //
    public void setMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = health;
    }

    //move slider on health bar 
    public void SetHealth(int health)
    {
        slider.value = health;
    } 
}
