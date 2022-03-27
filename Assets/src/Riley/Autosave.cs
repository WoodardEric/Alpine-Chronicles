using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Autosave : MonoBehaviour
{
	public static PlayerData Activesave; 
	public float Timer = 0;
	public bool SaveGame = false;
	public float Timecheck = 1800f;
	public PlayerClass _player = null;
	public static int heart; 


	// Start is called before the first frame update
	void Start()
	{
		_player = PlayerClass.Instance;
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
			SavePlayerFunc();
			Timer = 0f;
		}
	}
	
	public void savelevel()
	{   //Get active scene
		PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);

	}

	public static void SavePlayerFunc()
	{
		//save the data in binary, more secure
		BinaryFormatter formatter = new BinaryFormatter();

		//create a path using application.p...
		string path = Application.persistentDataPath + "/data.ap";

		//Create a stream
		FileStream stream = new FileStream(path, FileMode.Create);

		//set the stream to the new gameobject, for PlayerData script.
		Debug.Log("Health is " +heart);
		PlayerData data = new PlayerData();
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
		//Load the level using player prefs. 
		Debug.Log("Loading scene");
		SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
		PlayerClass player = PlayerClass.Instance;
		player.setPlayerPos(new Vector2(-5.18f, -2.87f));

		string path = Application.persistentDataPath + "/data.ap";
		BinaryFormatter formatter = new BinaryFormatter();
		//Create a stream
		FileStream stream = new FileStream(path, FileMode.Open);
		//cast it as a playerClass
		PlayerData data = (PlayerData)formatter.Deserialize(stream);
		//_player = formatter.Deserialize(stream) as PlayerData;
		//formatter.Deserialize(stream);
		Debug.Log(data);
		stream.Close();
	}

}

[System.Serializable]
public class PlayerData
{
	public static int heartt;

	public PlayerData()
	{
		heartt = Autosave.heart;
	}



}