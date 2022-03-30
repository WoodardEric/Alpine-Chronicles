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
        //healthy = myObject.GetHealth();
        //PlayerPrefs.GetInt("health");
    }


    // Update is called once per frame
    void Update()
    {
       

    }


    public void Create()
    { 
    
    
    }


    public void SaveGame()
    {
        savelevel(); 
        //public int healthy = player.health;
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health", healthy);
        Debug.Log("saving..." + healthy);

    }


    public void LoadGame()
    {
        LoadLevel(); 
        int healthy = PlayerPrefs.GetInt("health");
        player.health = healthy;
        //player.UpdateHealth(healthy);
        //healthy =  PlayerPrefs.GetInt("health");
        Debug.Log("Loading..." + healthy);
    }


    public void savelevel()
    {   //Get active scene
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadLevel()
    {
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        PlayerClass player = PlayerClass.Instance;
        player.IsInteracting(false);
        player.SetPlayerPos(new Vector2(-5.18f, -2.87f));
    }


}
