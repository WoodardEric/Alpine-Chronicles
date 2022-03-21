using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadGame()
   {
        Debug.Log("Loading scene");
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        PlayerClass player = PlayerClass.Instance;
        player.setPlayerPos(new Vector2(-5.18f, -2.87f));
    } 
        
}
