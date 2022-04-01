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

		int count = 0;
		//float timer = 0.0f;
	   
		//timer += Time.deltaTime;
	    //float seconds = timer % 60;
	   // Debug.Log("Time "+seconds);

		int timer = 0;
		int max = 10000;

		while (timer < max)
		{
			timer += 1;
			System.Threading.Thread.Sleep(1000);
		}
	
		Debug.Log("Count " + timer);
		//Debug.Log("testing");
		/*
		while (true)
        {		
			bool exist;

			//save the data in binary, more secure.
			BinaryFormatter formatter = new BinaryFormatter();
			string loc = Application.persistentDataPath + "/newtest.ap";
			FileStream file = new FileStream(loc, FileMode.OpenOrCreate);

			// Fill the File with player/level data here//

			file.Close();

			//check if file was created, to confirm save works. 
			if (System.IO.File.Exists(loc))
			{
				Debug.Log("File exists, forever saving...");
				exist = true;

			}

			else
			{
				exist = false;
				Debug.Log("File does not exist in the current directory!");
			}

			Assert.IsTrue(exist, "The File exists");
			
			//!! Deleting sleep could cause your computer to crash!!//
			//Change the sleep number slowly i.e 3 seconds, 2 secs, 1.//

			Thread.Sleep(5000);
			yield return null;
		}
		
	}	
	[TearDown]
	public void teardown()
    {
		SceneManager.UnloadSceneAsync("StressLevel");

    }*/

		Thread.Sleep(6000);
		yield return null;
	}
}