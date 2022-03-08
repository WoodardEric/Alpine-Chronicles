using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
        public void PlayGame()
        {
            //to load the next scene in the queue
            Debug.Log("change to level_0 scene");
            SceneManager.LoadScene("Level_0");
            PlayerClass player = PlayerClass.Instance;
            player.setPlayerPos(new Vector2(-5.18f, -2.87f));
        }

        public void drBcMode()
        {
            Debug.Log("pull up password input text");
            SceneManager.LoadScene("inputPassword");
        }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}