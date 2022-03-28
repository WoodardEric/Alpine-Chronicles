using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    PlayerClass player = null;

    private void Start()
    {
        player = PlayerClass.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        GameIsPaused = false;
        player.IsInteracting(false);
    }

    //function temporarily here 
    public void MainMenu()
    {
        Debug.Log("load menu");
        Time.timeScale = 1f;
        player.SetPlayerPos(new Vector2(-38.5f, -2.67f));
        SceneManager.LoadScene("menu");
    }

    void Pause()
    {
        Debug.Log("Pause Game");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        GameIsPaused = true;
        player.IsInteracting(true);
    }

    //save game
    public void Save()
    {
        Debug.Log("save button pressed");
    }

    //tempory function going to put into other class
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}