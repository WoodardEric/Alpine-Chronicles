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
	public PlayerClass player = null;
	public SaveAll Select;
	public GameObject Player; 

	// Start is called before the first frame update
	void Start()
	{
		Select = Player.GetComponent<SaveAll>();
		player = PlayerClass.Instance;
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
            Select.Save(); 
			Timer = 0f;
		}
	}
       
}

public class SaveAll : MonoBehaviour
{
	public PlayerClass pplayer = null;
	// Start is called before the first frame update
	void Start()
	{
		pplayer = PlayerClass.Instance;
	}


	public void Save()
	{
		//PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
		//SaveWorld();
		//public int healthy = player.health;
		int healthyy = pplayer.GetHealth();
		PlayerPrefs.SetInt("health", healthyy);
		Debug.Log("saving..." + healthyy);

	}


	public void SaveWorld()
	{   //Get active scene
		//PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
		//PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
		PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
	}



}
