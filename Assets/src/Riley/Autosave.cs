using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 


public class Autosave : MonoBehaviour
{
	public float Timer = 0;
	public bool SaveGame = false;
	public float Timecheck = 1800f;

	public PlayerData  _player;

	//Make sure to create a gameobject for our _player data. 
	public void Awake()
	{
		_player = GameObject.FindObjectOfType<PlayerData>();
	
	}
	
	// Start is called before the first frame update
	void Start()
	{
		Timer = Timer + 1 * Time.deltaTime;

		//loop auto saveusing coroutine if needed
		//StartCoroutine(Countdown3());
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
			SavePlayerFunc();
			Timer = 0f;
			}
	}
	
	//coroutine if using will continue to loop forever. 
	/*
	private IEnumerator Countdown3()
	{
		while (true)
		{
			yield return new WaitForSeconds(3); //wait 3 seconds
												//do other thing
			Debug.Log("AutoSaving Data...");
		}
	}*/
	
	public void SavePlayerFunc() 

	{
		//save the data in binary, more secure
		BinaryFormatter formatter = new BinaryFormatter();

		//create a path using application.p...
		string path = Application.persistentDataPath + "/data.ap";

		//Create a stream
		FileStream stream = new FileStream(path, FileMode.Create);

		//set the stream to the new gameobject, for PlayerData script.
		formatter.Serialize(stream, _player.myStats);
		
		//print out file location
		Debug.Log(Application.persistentDataPath);

		stream.Close();
		
	}




}