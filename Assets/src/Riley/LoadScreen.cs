/*
 * Filename:  LoadScreen.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains a class that creates a load screen for the load button.  
 */


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.IO;


/*
* Summary: This Class is for creation of the load screen
*
* Member Variables:
* slider- a slider object, saved as slider value. 
* count- counts the # of active scene.
* progressText- text to show loading value in %. 
*/


public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public SaveScript count;
    public Text progressText; 


   /*
    * Summary: Load the current scene
    */
    public void LoadLevel(int sceneIndex)
    {
        sceneIndex = count.track; 
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }


   /*
    * Summary: Get current scene and activate load screen.
    */
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        sceneIndex = count.track;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
           
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null; 
        
        }
    
    }

}
