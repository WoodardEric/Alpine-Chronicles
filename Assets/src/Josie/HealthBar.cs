/*
 * Filename:  HealthBar.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains the healthbar class that updates the healthbar ui
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Summary: This Class is HealthBar class that deals with health bar prefab 
 *
 * Member Variables: 
 * slider: Type Slider, which moves healthbar slider 
 * player: creates playerClass variable player
 */
public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    public PlayerClass player = null;

    public static HealthBar Instance { get; private set; }

    /*
     * Summary: Ensures that only one instance of the healthbar is created
     */

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Create healthbar and keep between scenes
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    /*
     * Summary: creates instance of player class
     */
    void Start()
    {
        player = PlayerClass.Instance;  
    }
    

    /*
     * Summary: gets player health and sets health
     */
    void Update()
    {
        int i = player.GetHealth();
        SetHealth(i);
    }
    

    /*
     * Summary: set max health for slider
     */
    public void setMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = health;
    }


    /*
     * Summary: Sets health on slider ui 
     */
    public void SetHealth(int health)
    {
        slider.value = health;
    } 
}
