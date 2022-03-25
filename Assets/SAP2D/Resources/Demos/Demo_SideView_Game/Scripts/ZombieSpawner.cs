using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour {

	public static List<GameObject> Zombies = new List<GameObject>();
	public Transform[] spawnPoints;
	public int SpawnNumber;
	public float spawnTime;
	public GameObject ZombiePrefab;
	
	private GameObject player;
	private int zombieSpawnCount;

	void Start(){
		Spawn ();
	}

	void Update(){

		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			if (Zombies.Count == 0) {
				SpawnNumber = SpawnNumber * 2;
			}

			Spawn();
			spawnTime = 0.3f;
		}
	}

	void Spawn(){
		if (zombieSpawnCount <= SpawnNumber) {
			Vector3 spawnPos = spawnPoints [Random.Range (0, spawnPoints.Length)].position;
			
			GameObject zombie = Instantiate (ZombiePrefab, spawnPos, Quaternion.identity) as GameObject;
			Zombies.Add (zombie);
			zombieSpawnCount++;
		} 
	}
}
