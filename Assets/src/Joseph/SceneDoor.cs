/*
 * Filename: SceneDoor.cs
 * Developer: Joseph
 * Purpose: Facilite a way for the player to change scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

/*
 * Summary: Change between scenes
 *
 * Member Variables
 * toScene - integer representing the scene to be changed to
 * fromScene - integer representing the current scene
 */
public class SceneDoor : Door
{
    public int toScene;
    public int fromScene;
    //LevelManager LM = LevelManager.Instance;

    /*
     * Summary: Attempt to change the scene
     */
    override public void Open()
    {
        LevelManager.Instance.ChangeScene(toScene,fromScene);
        //LM.changeScene(toScene,fromScene);
        Debug.Log("Change Scene");
    }
}