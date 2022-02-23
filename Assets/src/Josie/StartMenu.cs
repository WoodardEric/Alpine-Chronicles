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
