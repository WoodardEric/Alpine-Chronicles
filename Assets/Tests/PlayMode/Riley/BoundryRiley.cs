using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TestRiley
{
    //Save the file (First boundry test.)
    [UnityTest, Order(1)]
    public IEnumerator TestRileyWithEnumeratorPasses()
    {
	    int Highscore;
		Highscore = 500; 
		PlayerPrefs.SetInt("score", Highscore); 
		bool exist;

		if (PlayerPrefs.HasKey("score"))
		{
			exist = true;
			Debug.Log("Score exists Saved: " + Highscore);
			//Highscore = PlayerPrefs.GetInt("score");
		}

		else
		{
			exist = false;
			Debug.Log("File does not exist in the current directory!");
		}

		Assert.IsTrue(exist, "The File exists");
		yield return new WaitForSeconds(1f); 
    }

	//Open and load the File (Second boundry test).
	[UnityTest, Order(2)]
	public IEnumerator LoadRileyWithEnumeratorPasses()
	{
		int score = 1000; 
		bool alive;
		PlayerPrefs.SetInt("score", score);

		if (PlayerPrefs.HasKey("score"))
		{
			alive = true;
			score = PlayerPrefs.GetInt("score");
			Debug.Log("Score exists Loaded: " + score);
		}

		else
		{
			alive = false;
			Debug.Log("File does not exist in the current directory!");
		}	

		Assert.IsTrue(alive, "The File has opened.");
		yield return new WaitForSeconds(2f);
	}
	//Delete file and start over
}
