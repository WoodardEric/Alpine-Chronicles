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
			bool exist; 
		
			//save the data in binary, more secure
			BinaryFormatter formatter = new BinaryFormatter();

			//create a path using application.p...
			string loc = Application.persistentDataPath + "/test.ap";

			//Create a stream
			FileStream file = new FileStream(loc, FileMode.Create);
		 
			// Fill the File with player/level data here//

			//print out file location
			Debug.Log(Application.persistentDataPath);

			file.Close();

		if (System.IO.File.Exists(loc))
		{
			Debug.Log("File exists, saving...");
			exist = true;
		}

		else
		{
			exist = false; 
			Debug.Log("File does not exist in the current directory!");
		}

		Assert.IsTrue(exist, "The File exists");
		yield return new WaitForSeconds(1f); 
    }

	//Open the File (Second boundry test).
	[UnityTest, Order(2)]
	public IEnumerator LoadRileyWithEnumeratorPasses()
	{
		bool alive;
		string loc = Application.persistentDataPath + "/test.ap";

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(loc, FileMode.Open);

		stream.Close();

		//change this to open the file path
		var fileContent = File.ReadAllBytes(loc);

		if (fileContent !=null)
		{
			Debug.Log("File Read...");
			alive = true;
		}

		else 
		{
			
			Debug.Log("File does not exist in the current directory!");
			alive = false;
		}
		Assert.IsTrue(alive, "The File exists");
		yield return new WaitForSeconds(2f);
	}



	[TearDown]
	public void TearDown()
	{
		File.Delete(Application.persistentDataPath + "test.ap");
		UnityEditor.AssetDatabase.Refresh();
	}
}
