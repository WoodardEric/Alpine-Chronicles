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
* Summary: This Class sets a timer that is set to activate AutoSave. 
*
* Member Variables:
* Timer- int Counts per second.
* Timecheck- int Sets the time of when to activate Autosaveyy.
* SaveGame- bool Flag that activates Autosaveyy. 
* Saveit- Game object to access Autosaveyy functions
*/

public class AsTimer : MonoBehaviour
{
    public float timer = 0;
	public bool saveGame = false;
	public float timeCheck = 1800f;
	public  Autosaveyy Saveit;
	 

  /*
   * Summary: Set timer to seconds in realtime. 
   */
	void Start()
	{
		timer = timer + 1 * Time.deltaTime;
	}


  /*
   * Summary: Activate Autosaveyy when timer reaches timecheck. 
   */
	void Update()
	{
		timer = timer + 1 * Time.deltaTime;
		if (timer >= timeCheck)
		{
			saveGame = true;

		}

		if (saveGame == true)
		{
			saveGame = false;
			Saveit.BackupPlayer();
			Saveit.BackupLevel();

			Debug.Log("AutoSaving Data...");
			timer = 0f;
		}
	}


}