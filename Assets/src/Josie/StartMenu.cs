/*
 * Filename:  PauseMenu.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains the class StartMenu, that deals with Button UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Summary: This Class is the start menu class dealing with  UI 
 *
 * Member Variables: 
 * Player: creates variable of type PlayerClass that is used to get score of player
 *
 */
public class StartMenu : MonoBehaviour
{
    PlayerClass player = null;
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("LoadingCanvas");
        loadingScreen = canvas.transform.GetChild(0).gameObject;
        slider = loadingScreen.GetComponentInChildren<Slider>();
    }

    /*
     * Summary: sets player and chages scenes 
     */
    public void PlayGame()
    {
        player.IsInteracting(false);
        //to load the next scene in the queue
        Debug.Log("change to level_0 scene");
        
        StartCoroutine(LoadAsyncronously("Level_0"));

        player.SetPlayerPos(new Vector2(-5.18f, -2.87f));
        player.ResetPlayer();
    }

    IEnumerator LoadAsyncronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }

    IEnumerator LoadAsyncronously(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }


    /*
     * Summary: Changed scenes drBcmode input password scene
     */
    public void drBcMode()
    {
        Debug.Log("pull up password input text");
        SceneManager.LoadScene("inputPassword");
    }


    /*
     * Summary: Changed scenes to saved scene
     */
    public void LoadGame()
    {
        StartCoroutine(LoadAsyncronously(PlayerPrefs.GetInt("SavedScene")));
    }   


     /*
     * Summary: creates instance of the player
     */
    void Start()
    {
        player = PlayerClass.Instance;
        player.IsInteracting(true);

        MenuManager menu = new MenuManager();

        menu.SayHello();

        drbcMode bc = new drbcMode();

        bc.SayHello();
    }
}