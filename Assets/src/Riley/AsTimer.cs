using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class AsTimer : MonoBehaviour
{
	public float Timer = 0;
	public bool SaveGame = false;
	public float Timecheck = 1800f;
	public AutoSave Saveit; 
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
			Saveit.SavePlayer();
			Saveit.SaveLevel();

			Debug.Log("AutoSaving Data...");
			Timer = 0f;
		}
	}


}