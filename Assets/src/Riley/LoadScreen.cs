using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public SaveScript count; 
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

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null; 
        
        }
    
    }

}
