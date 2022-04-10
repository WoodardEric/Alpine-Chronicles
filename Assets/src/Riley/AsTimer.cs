using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AsTimer : MonoBehaviour
{
	public float Timer = 0;
	public bool SaveGame = false;
	public float Timecheck = 1800f;
	public Autosaveyy Saveit; 
	// Start is called before the first frame update
	void Start()
	{
		//Saveit = this.AddComponent<AutoSave>();
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
			SaveGame = false;
			Saveit.SavePlayer();
			Saveit.SaveLevel();

			Debug.Log("AutoSaving Data...");
			Timer = 0f;
		}
	}


}