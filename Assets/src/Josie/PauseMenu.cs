/*
 * Filename:  PauseMenu.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains the class PauseMenu that deals with UI pause menu
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

/*
 * Summary: This Class is PauseMenu class, it activates and deactivates pause menu
 *          It also contains the the button functions 
 *
 * Member Variables: 
 * GameIsPaused: bool variable 
 * pauseMenuUI: gameobject that is set active or not active like a popup screen
 * player: PlayerClass type initiated variable
 *
 */
public class PauseMenu : MenuManager
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    PlayerClass player = null;
    

    /*
     * Summary: creates instance of player
     */
    private void Start()
    {
        player = PlayerClass.Instance;
    }
    

    /*
     * Summary: Resume button, sets game object to false 
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        GameIsPaused = false;
        player.IsInteracting(false);
    }

    /*
     * Summary: main button, sets game object to false 
     */
    public override void MainMenu()
    {
        Debug.Log("load menu");
        Time.timeScale = 1f;
        player.SetPlayerPos(new Vector2(-38.5f, -2.67f));
        SceneManager.LoadScene("menu");
    }

    /*
     * Summary: pause button, sets Gameobject true 
     */
    public void Pause()
    {
        Debug.Log("Pause Game");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        GameIsPaused = true;
        player.IsInteracting(true);
    }


    /*
     * Summary: quit button, quits application
     */
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        SceneManager.LoadScene("menu");
    }
}