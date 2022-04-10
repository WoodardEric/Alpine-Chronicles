/*
 * Filename:  Autosaveyy.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains a class that saves and loads gamedata. 
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/*
* Summary: This Class is for autosaving all the gamedata. 
*
* Member Variables:
* player-  object to access tobys PlayerClass script.
*/
public class Autosaveyy : MonoBehaviour
{
    public PlayerClass player = null;


  /*
   * Summary: Get instance of Playerclass on start. 
   */
    void Start()
    {
        player = PlayerClass.Instance;
    }


  /*
   * Summary: Saves the Player Data only. 
   */
    public void SavePlayer()
    {
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health", healthy);
        PlayerPrefs.SetInt("score", player.GetScore());
        Vector2 pos = player.GetPos();
        PlayerPrefs.SetFloat("xPos", pos.x);
        PlayerPrefs.SetFloat("yPos", pos.y);
        Debug.Log("Saving...");
    }


  /*
   * Summary: Saves the Level Data only. 
   */
    public void SaveLevel()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }

}
