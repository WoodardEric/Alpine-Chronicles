using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    public PlayerClass player = null;
    public CoinPickup Scored;
   
    GameObject something; 
    public float x, y, z; 
    void Start()
    {
 

        player = PlayerClass.Instance;
    }

    public void SaveGame()
    {
        
        SaveLevel();

        int healthy = player.GetHealth();
        int HighScore = player.GetScore();

        PlayerPrefs.SetInt("health", healthy);
        PlayerPrefs.SetInt("score", HighScore);
        Debug.Log("Saving...");

    }

    public void LoadGame()
    {
        LoadLevel(); 
        int healthy = PlayerPrefs.GetInt("health");
        int HighScore = PlayerPrefs.GetInt("score");

        player.health = healthy;
        CoinPickup.score = HighScore; 
       
        Debug.Log("Loading...");
    }

    public void SaveLevel()
    {           
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex); 
    }


    public void LoadLevel()
    {
        PlayerClass player = PlayerClass.Instance;
        player.IsInteracting(false);

        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));

        //This loads the player position of 0, which is automatically set to 0 in everygame, through other player scripts.. 
        // I cannot set the players position in save, due to other scripts setting to 0. 
        PlayerPrefs.GetFloat("x", x);
        PlayerPrefs.GetFloat("y", y);
        PlayerPrefs.GetFloat("z", z);

        Vector3 LoadPosition = new Vector3(x, y, z);
        player.transform.position = LoadPosition; 

        
    }

}
