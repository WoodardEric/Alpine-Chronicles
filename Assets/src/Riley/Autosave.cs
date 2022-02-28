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
			//SavePlayerFunc(playerClass);
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
	
	public static void SavePlayerFunc() //insert player data here

	{
		//save the data in binary, more secure
		BinaryFormatter formatter = new BinaryFormatter();

		string path = Application.persistentDataPath + "/data.ap";
		FileStream stream = new FileStream(path, FileMode.Create);

		//PlayerData data = new PlayerData(pplayer);
		//formatter.Serialize(stream, data);
		
		Debug.Log(Application.persistentDataPath);
		stream.Close();
		
	}




}