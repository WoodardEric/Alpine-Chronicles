using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    PlayerClass player = null;
        public void PlayGame()
        {
            player.IsInteracting(false);
            //to load the next scene in the queue
            Debug.Log("change to level_0 scene");
            SceneManager.LoadScene("Level_0");
            player.SetPlayerPos(new Vector2(-5.18f, -2.87f));
        }

        public void drBcMode()
        {
            Debug.Log("pull up password input text");
            SceneManager.LoadScene("inputPassword");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        }   
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerClass.Instance;
        player.IsInteracting(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}