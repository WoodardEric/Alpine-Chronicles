using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Autosave : MonoBehaviour
{

	public float Timer = 0;
	public bool SaveGame = false;
	public float Timecheck = 1800f;

	public int heart; 
	public PlayerClass _player = PlayerClass.Instance;

	// Start is called before the first frame update
	void Start()
	{
		//public int heart;

	    heart = _player.getHealth(); 
		Timer = Timer + 1 * Time.deltaTime;

	}
	// Update is called once per frame
	void Update()
	{
		Timer = Timer + 1 * Time.deltaTime;
		if (Timer >= Timecheck)
		{
			SaveGame = true;

		}

		if (SaveGame == true)
		{
			Debug.Log("AutoSaving Data...");
			savelevel();
			savefunction();
			Timer = 0f;
		}
	}

	public void savefunction()
	{   //Create the same thing here as save load manager, you have to pass in data to auto save. 
		//SaveLoadManager.SavePlayerFunc(PlayerClass, player);
	}

	public void savelevel()
	{   //Get active scene
		PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);

	}

}

public class SaveLoadManager : MonoBehaviour
{
	public static void SavePlayerFunc(PlayerClass _player)
	{
		//save the data in binary, more secure
		BinaryFormatter formatter = new BinaryFormatter();

		//create a path using application.p...
		string path = Application.persistentDataPath + "/data.ap";

		//Create a stream
		FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

		//set the stream to the new gameobject, for PlayerData script.

		Playerinfo data = new Playerinfo(_player);
		formatter.Serialize(stream, data);

		//print out file location
		Debug.Log(Application.persistentDataPath);

		stream.Close();

		if (System.IO.File.Exists(path))
		{
			//Debug.Log("File exists...");
		}
		else
		{
			Debug.Log("File does not exist in the current directory!");
		}

	}

	public static void load()
	{
		string path = Application.persistentDataPath + "/data.ap";
		BinaryFormatter formatter = new BinaryFormatter();
		//Create a stream
		FileStream stream = new FileStream(path, FileMode.Open);
		//cast it as a playerClass
		Playerinfo data = (Playerinfo)formatter.Deserialize(stream);
		//_player = formatter.Deserialize(stream) as PlayerData;
		Debug.Log("file loaded");
		stream.Close();
	}
}

[System.Serializable]
public class Playerinfo
{
	public int[] stats;

	public Playerinfo(PlayerClass player)
	{
		stats = new int[4];
		//stats[0] = player.health; 

	}
}