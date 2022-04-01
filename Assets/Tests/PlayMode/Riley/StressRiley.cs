using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
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
	
		while (timer < max)
		{
			timer += 1;

			//change sleep value to milliseconds to try crashing system. 
			System.Threading.Thread.Sleep(1000);
			//System.Threading.Thread.Sleep(500);
			//System.Threading.Thread.Sleep(100);
		}

		PlayerPrefs.SetInt("Score", timer);
		
		if (PlayerPrefs.HasKey("Score"))
		{
			Debug.Log("Score saved every Second/millisecond, the score is: " + timer);
		}

		else
		{
			Debug.Log("Score doesn't exist");
		}
		yield return null;
	}
}