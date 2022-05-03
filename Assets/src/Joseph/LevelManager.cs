/*
 * Filename: LevelManager.cs
 * Developer: Joseph
 * Purpose: Control the changing of scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Summary: Control the changing of scenes
 *
 * Member Variables:
 * goodScene - integer value used to test if an input is good
 * test - boolean value used to access code only avalible during tests
 * levelOneFog - string list for the fog for level one
 * levelTwoFog - string list for the for for level two
 * prevScene - the scene of the last frame call
 * currScene - the scene of the current frame call
 */
public class LevelManager : MonoBehaviour
{
    public int goodScene;
    public bool test = false;
    List<string> levelOneFog = new List<string>();
    List<string> levelTwoFog = new List<string>();
    List<string> keyDoors = new List<string>();
    Scene prevScene;
    Scene currScene;
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject canvas;


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
        canvas = GameObject.Find("LoadingCanvas");
        loadingScreen = canvas.transform.GetChild(0).gameObject;
        slider = loadingScreen.GetComponentInChildren<Slider>();
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

        StartCoroutine(LoadAsyncronously(toScene));

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
    }


    IEnumerator LoadAsyncronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }


    /*
     * Summary: Return the list of fog for the corresponding level
     *
     * Parameter:
     * level - integer meant to represent the scene in the build order
     *
     * Returns:
     * List<string> - return the level fog array requested, return null if invalid input
     */
    public List<string> GetLevelFog(int level)
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
     * Summary: Return the list of key doors
     *
     * Returns:
     * List<string> - return the opened key doors
     */
    public List<string> GetKeyDoors()
    {
        return keyDoors;
    }


    /*
     * Summary: Update the proper fog level array with the disabled fog
     *
     * Parameter:
     * level - integer representing the scene number of the level wanted
     * name - string representing the name of the fog to be added
     */
    public void UpdateLevel(int level, string name)
    {
        if(level == 2)
        {
            if(levelOneFog.Contains(name))
            {
                Debug.Log(name + " already exists in levelOneFog");
            }
            else
            {
                levelOneFog.Add(name);
                Debug.Log("Added " + name + " to levelOneFog");
            }
        }
        else if(level == 3)
        {
            if(levelTwoFog.Contains(name))
            {
                Debug.Log(name + " already exists in levelTwoFog");
            }
            else
            {
                levelTwoFog.Add(name);
                Debug.Log("Added " + name + " to levelTwoFog");
            }
        }
    }

    /*
     * Summary: Attempt to add a KeyDoor name to keyDoors
     *
     * Parameters:
     * name - a string representing the name of the door
     */
    public void UpdateLevel(string name)
    {
        if(keyDoors.Contains(name))
        {
            Debug.Log(name + " already exists in keyDoors");
        }
        else
        {
            keyDoors.Add(name);
            Debug.Log("Added " + name + " to keyDoors");
        }
    }


    /*
     * Summary: Set the fog in a scene to the values stored in the proper level fog array
     *
     * Parameter:
     * level - integer representing the scene number of the level wanted
     */
    public void SetLevel(int level)
    {
        GameObject[] fogArray;
        GameObject door;
        int i;

        if((level == 2) && (levelOneFog.Count != 0))
        {
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            for(i = 0; i < fogArray.Length; i++)
            {
                if(levelOneFog.Contains(fogArray[i].name))
                {
                    fogArray[i].SetActive(false);
                    Debug.Log("Disabled " + fogArray[i].name);
                }
            }
        }
        else if(level == 3)
        {
            fogArray = GameObject.FindGameObjectsWithTag("Fog");

            for(i = 0; i < fogArray.Length; i++)
            {
                if(levelTwoFog.Contains(fogArray[i].name))
                {
                    fogArray[i].SetActive(false);
                    Debug.Log("Disabled " + fogArray[i].name);
                }
            }
        }

        for(i = 0; i < keyDoors.Count; i++)
        {
            door = GameObject.Find(keyDoors[i]);

            if(door != null)
            {
                door.SetActive(false);
            }
        }
    }


    /*
     * Summary: Check to see if a new scene has loaded and set the fog if it has, also set the level music
     */
    public void Update()
    {
        currScene = SceneManager.GetActiveScene();

        if(currScene != prevScene)
        {
            prevScene = currScene;
            Debug.Log("SetLevelFog " + currScene.buildIndex);
            SetLevel(currScene.buildIndex);

            //Level music
            if(currScene.buildIndex == 1)
            {
                MusicManager.Instance.Play(MusicManager.MusicTrack.Menu);
            }
            else if(currScene.buildIndex == 2)
            {
                MusicManager.Instance.Play(MusicManager.MusicTrack.SceneTwo);
            }
            else if(currScene.buildIndex == 3)
            {
                MusicManager.Instance.Play(MusicManager.MusicTrack.SceneThree);
            }
        }
        else
        {
            prevScene = currScene;
        }
    }

}