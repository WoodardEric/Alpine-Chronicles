/*
 * Filename:  SaveScript.cs
 * Developer: Riley Walsh
 * Purpose:   This file contains a class that saves and loads gamedata. 
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* Summary: This Class acts as both saving and loading of gamedata using playerprefs. 
*
* Member Variables:
* player-  object to access tobys PlayerClass script.
*/
public class SaveScript : MonoBehaviour
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
   * Summary: Saves the entire gamedata, player, level, etc. 
   */
    public void SaveGame()
   {

       SaveLevel();

       int healthy = player.GetHealth();
       int HighScore = player.GetScore();
       Vector2 pos = player.GetPos();

       PlayerPrefs.SetInt("health", healthy);
       PlayerPrefs.SetInt("score", HighScore);
       PlayerPrefs.SetFloat("xPos", pos.x);
       PlayerPrefs.SetFloat("yPos", pos.y);
       Debug.Log("Saving...");

   }


  /*
   * Summary: Saves the level the player is on. 
   */
    public void SaveLevel()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }


  /*
   * Summary: Laods the entire gamedata, player, level, etc. 
   */
    public void LoadGame()
   {
       LoadLevel(); 

       int healthy = PlayerPrefs.GetInt("health");
       int HighScore = PlayerPrefs.GetInt("score");

       player.SetHealth(healthy);
       CoinPickup.SetScore(HighScore); 
       player.SetPlayerPos(new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos")));

       Debug.Log("Loading...");
   }


  /*
   * Summary: Loads the level the player is on. 
   */
    public void LoadLevel()
   {
       PlayerClass player = PlayerClass.Instance;
       player.IsInteracting(false);
       SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));

   }

}
