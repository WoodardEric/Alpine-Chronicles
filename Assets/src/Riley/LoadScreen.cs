using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System.IO;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public SaveScript count;
    public Text progressText; 
    // Start is called before the first frame update
    public void LoadLevel(int sceneIndex)
    {
        //sceneIndex = count.track;

        
        StartCoroutine(LoadAsynchronously(sceneIndex));
        

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //sceneIndex = count.track;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
           
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null; 
        
        }
    
    }

}
