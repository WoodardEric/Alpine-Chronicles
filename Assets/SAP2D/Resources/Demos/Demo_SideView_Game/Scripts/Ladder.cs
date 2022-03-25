using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public Transform StartPosition;
	public Transform EndPosition;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Miner") {
			col.GetComponent<Miner>().OnLadder = true;
			col.GetComponent<Miner>().startClimbPos = StartPosition.position;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Miner") {
			col.GetComponent<Miner>().OnLadder = false;
		}
	}
}
