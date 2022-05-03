/*
 * Filename:  MenuManager.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains MenuManger parent class 
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

/*
 * Summary: This Class is MenuManager Parent class
 *
 * Member Variables: 
 * player: PlayerClass type initiated variable
 *
 */
public class MenuManager : MonoBehaviour
{
    PlayerClass player = null;


     /*
     * Summary: creates instance of player
     */
    void Start()
    {
        player = PlayerClass.Instance;
    }
    

     /*
     * Summary: change scene to main menu buttons
     */
    public virtual void MainMenu()
    {
        Debug.Log("load menu");
        Time.timeScale = 1f;
        //player.SetPlayerPos(new Vector2(-38.5f, -2.67f));
        SceneManager.LoadScene("menu"); 
    }

    public virtual void SayHello()
    {
        Debug.Log("Hello, from menu manager");
    }
}