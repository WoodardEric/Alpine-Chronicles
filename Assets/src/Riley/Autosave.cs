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
	public float Timecheck = 5f;

	// Start is called before the first frame update
	void Start()
	{
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
			SaveGameFunc();
			Timer = 0f;
			

		}

	}

	public static void SaveGameFunc() //insert player data here

	{
		//save the data in binary, more secure
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/data.ap";
		FileStream stream = new FileStream(path, FileMode.Create);

		//save player data here
		//save level data here
		Debug.Log("AutoSaving Data...");
		Debug.Log(Application.persistentDataPath);
		stream.Close();
		

	}


}