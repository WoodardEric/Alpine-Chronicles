/*
 * Filename: LevelManager.cs
 * Developer: Joseph
 * Purpose: Control the changing of scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: Control the changing of scenes
 *
 * Member Variables:
 * goodScene - integer value used to test if an input is good
 * test - boolean value used to access code only avalible during tests
 */
public class LevelManager : MonoBehaviour
{
    public int goodScene;
    public bool test = false;

	/*
	 * Summary: Set up this class as a Singleton
	 */
    public static LevelManager Instance
	{
		get;
		private set;
	}

    /*
	 * Summary: Ensure only one instance of this class exists at a time
	 */
    private void Awake()
    {
        // Ensure that only one instance of the LevelManager can exist
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Create LevelManager and keep it between scenes
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    /*
	 * Summary: Change scenes if the inputs are within a correct range
     *
     * Parameters:
     * toScene - integer value representing the scene to change to
     * fromScene - integer value representing the current scene
	 */
    public void ChangeScene(int toScene, int fromScene)
    {
        PlayerClass player = PlayerClass.Instance;
        Vector2 loadPos = new Vector2(0,0);
        goodScene = 1;

        //Ensure toScene is in the proper range
        if((toScene < 1) || (toScene > 3))
        {
            Debug.Log(toScene + " Is Not A Valid toScene Number");
            goodScene = 0;
        }
        //Ensure fromScene is in the proper range
        if((fromScene < 1) || (fromScene > 3))
        {
            Debug.Log(fromScene + " Is Not A Valid fromScene Number");
            goodScene = 0;
        }

        //Do not change the scene if either fromScene or toScene is improper or if testing
        if((goodScene == 0) || (test==true))
        {
            return;
        }

        //Change scene and move the player to the proper location
        SceneManager.LoadScene(toScene);
        if(toScene == 1)
        {
            loadPos.x = -9f;
            loadPos.y = -3.9f;
            player.SetPlayerPos(loadPos);
        }
        else if(toScene == 2)
        {
            if(fromScene == 1)
            {
                loadPos.x = -9f;
                loadPos.y = 3.75f;
                player.SetPlayerPos(loadPos);
            }
            else if(fromScene == 3)
		    {
                loadPos.x = 7.5f;
			    loadPos.y = -106f;
                player.SetPlayerPos(loadPos);
		    }
        }
	    else if(toScene == 3)
	    {
            if(fromScene == 2)
		    {
                loadPos.x = -6f;
			    loadPos.y = 16f;
			    player.SetPlayerPos(loadPos);
		    }
	    }
    }
}