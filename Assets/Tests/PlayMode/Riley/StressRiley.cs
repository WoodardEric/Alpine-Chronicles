using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//using System;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

//Change sleep() down below to make this crash// 
public class StressRiley
{

	[SetUp]
	public void setup()
	{
		SceneManager.LoadScene("StressLevel");

	}

	[UnityTest]
	public IEnumerator StressRileyWithEnumeratorPasses()
	{
		int timer = 0;

		//change max value to run longer, or add more values to save in order to crash.
		int max = 5;
		//int max = 100;

		int[] randomArray = new int[10];
		
		while (timer < max)
		{
		timer += 1;
		//Fill a random array full of values to save every second.
		//change sleep value to milliseconds to try crashing system. 
		for (int arrayIndex = 0; arrayIndex < randomArray.Length; arrayIndex++)
			{
				randomArray[arrayIndex] = Random.Range(0, 10);
				Debug.Log("random" + arrayIndex);
				
			}

			System.Threading.Thread.Sleep(1000);
		}
		// I cant save arrays in playerprefs, but I can record the amount of arrays created using a timer. 
		PlayerPrefs.SetInt("Score", timer);

		if (PlayerPrefs.HasKey("Score"))
		{
			Debug.Log("random arrays created every second, the amount created is X" + timer);
		}

		else
		{
			Debug.Log("Score doesn't exist");
		}
		yield return null;
	}
}