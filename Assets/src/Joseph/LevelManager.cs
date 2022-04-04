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
 * levelOneFog - boolean list for the fog for level one
 * levelTwoFog - boolean list for the for for level two
 */
public class LevelManager : MonoBehaviour
{
    public int goodScene;
    public bool test = false;
    List<bool> levelOneFog = new List<bool>();
    List<bool> levelTwoFog = new List<bool>();

	/*
	 * Summary: Set up this class as a Singleton
	 */
    public static LevelManager Instance
	{
		get;
		private set;
	}


    /*
	 * Summary: Ensure only one instance of this class exists at a time and set the arrays to null
	 */
    private void Awake()
    {
        // Ensure that only one instance of the LevelManager can exist
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
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

        Debug.Log("UpdateLevelFog");
        UpdateLevelFog(fromScene);

        SceneManager.LoadScene(toScene);

        //Debug.Log("SetLevelFog");
        //SetLevelFog(toScene);

        //Put the player at the proper position
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

        Debug.Log("SetLevelFog");
        SetLevelFog(toScene);
    }


    /*
     * Summary: Return the array of fog for the corresponding level
     *
     * Parameter:
     * level - integer meant to represent the scene in the build order
     *
     * Returns:
     * GameObject[] - return the level fog array requested, return null if invalid input
     */
    public List<bool> GetLevelFog(int level)
    {
        if(level == 2)
        {
            return levelOneFog;
        }
        else if(level == 3)
        {
            return levelTwoFog;
        }
        else
        {
            return null;
        }
    }


    /*
     * Summary: Update the proper fog level array with the current true/false values
     *
     * Parameter:
     * level - integer representing the scene number of the level wanted
     */
    public void UpdateLevelFog(int level)
    {
        GameObject[] fogArray;
        int i;

        if(level == 2)
        {
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            for(i = 0; i < fogArray.Length; i++)
            {
                Debug.Log("Found "+fogArray[i].name);
                levelOneFog.Add(fogArray[i].activeSelf);
            }
        }
        else if(level == 3)
        {
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            for(i = 0; i < fogArray.Length; i++)
            {
                Debug.Log("Found "+fogArray[i].name);
                levelTwoFog.Add(fogArray[i].activeSelf);
            }
        }
    }


    /*
     * Summary: Set the fog in a scene to the values stored in the proper level fog array
     *
     * Parameter:
     * level - integer representing the scene number of the level wanted
     */
    public void SetLevelFog(int level)
    {
        GameObject[] fogArray;
        int i;

        if(level == 2)
        {
            //IEnumerator for waiting for screen load
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            Debug.Log("Please work this time "+fogArray.Length);
            for(i = 0; i < fogArray.Length; i++)
            {
                Debug.Log("Set "+fogArray[i].name);
                fogArray[i].SetActive(levelOneFog[i]);
            }
        }
        else if(level == 3)
        {
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            for(i = 0; i < fogArray.Length; i++)
            {
                Debug.Log("Set "+fogArray[i].name);
                fogArray[i].SetActive(levelTwoFog[i]);
            }
        }
    }
}