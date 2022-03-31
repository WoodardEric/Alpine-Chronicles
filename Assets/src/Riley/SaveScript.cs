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
    
    void Start()
    {
        player = PlayerClass.Instance;
    }

    public void SaveGame()
    {
        SaveLevel(); 
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health", healthy);
        Debug.Log("Saving...");

    }

    public void LoadGame()
    {
        LoadLevel(); 
        int healthy = PlayerPrefs.GetInt("health");
        player.health = healthy;
        Debug.Log("Loading...");
    }

    public void SaveLevel()
    {   
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadLevel()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));     
        PlayerClass player = PlayerClass.Instance;
        player.IsInteracting(false);
        player.SetPlayerPos(new Vector2(-5.18f, -2.87f));
        
        
        
    }

}
