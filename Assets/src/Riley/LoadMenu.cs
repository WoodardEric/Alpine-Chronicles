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
        float xPos, yPos;
        player.SetHealth(PlayerPrefs.GetInt("health"));
        player.SetScore(PlayerPrefs.GetInt("score"));
        Vector2 pos = player.GetPos();
        xPos = PlayerPrefs.GetFloat("xPos");
        yPos = PlayerPrefs.GetFloat("yPos", pos.y);
        player.SetPlayerPos(new Vector2(xPos, yPos));
    } 
        
}
