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
		
			//save the data in binary, more secure.
			BinaryFormatter formatter = new BinaryFormatter();
			string loc = Application.persistentDataPath + "/test.ap";
			FileStream file = new FileStream(loc, FileMode.Create);
		 
			// Fill the File with player/level data here//

			file.Close();

		//check if file was created, to confirm save works. 
		if (System.IO.File.Exists(loc))
		{
			Debug.Log("File exists, saving...");
			exist = true;

			//print out file location
			Debug.Log(Application.persistentDataPath);
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
		bool alive;

		string loc = Application.persistentDataPath + "/test.ap";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(loc, FileMode.Open);

		//deserialize data here and load it.// 

		//Check if stream has truly opened the file, it shouldn't be null. 
		if(stream != null){
			Debug.Log("File Opened");
			alive = true;
			stream.Close();
		}
		else 
		{
			Debug.Log("File does not exist in the current directory!");
			alive = false;
		}
		Assert.IsTrue(alive, "The File has opened.");
		yield return new WaitForSeconds(2f);
	}
	//Delete file and start over
	[TearDown]
	public void TearDown()
	{
		File.Delete(Application.persistentDataPath + "test.ap");
		UnityEditor.AssetDatabase.Refresh();
	}
}
