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
    }

    public void SavePlayer()
    {
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health", healthy);
        Debug.Log("Saving...");
    }

    public void SaveLevel()
    {   
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }

}
