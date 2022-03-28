using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
	//public heal objecty;
	public int heartt;

	public PlayerData()
	{
		heal myObject = GameObject.FindObjectOfType<heal>();
		heartt = myObject.healthy;
		Debug.Log("Health is " + heartt);
	}



}
/*
//Make system serializable so we can put in file stream. 
[System.Serializable]
public class PlayerData
{
	public int[] stats;
	public PlayerClass _player = null;
	public int heart;

	void Awake()
	{
		_player = PlayerClass.Instance;
		heart = _player.getHealth();
	}

	
	public PlayerData()
	{
		stats = new int[4];
		stats[0] = heart; 

	}
}
*/

