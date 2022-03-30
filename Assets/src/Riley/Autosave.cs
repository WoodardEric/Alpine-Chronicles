using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;


public class AutoSave : MonoBehaviour
{
    public PlayerClass player = null;

    void Start()
    {
        player = PlayerClass.Instance;
        //healthy = myObject.GetHealth();
        //PlayerPrefs.GetInt("health");
    }

    public void SaveGame()
    {
        savelevel();
        //public int healthy = player.health;
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health", healthy);
        Debug.Log("saving..." + healthy);

    }

    public void savelevel()
    {   //Get active scene
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }

}
