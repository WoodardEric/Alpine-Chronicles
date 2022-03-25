using UnityEngine;
using System.Collections;

public class pickaxe : MonoBehaviour {
	
	public float rotationSpeed;
	public float speed;
	public float Damage;
	public Vector3 mousePos;

	private Transform miner;

	void Start(){
		miner = FindObjectOfType<Miner> ().transform;
	}

	void Update () {
		transform.Rotate (-Vector3.forward * rotationSpeed * Time.deltaTime);
		transform.Translate(Vector3.Normalize(mousePos - miner.position)*Time.deltaTime*speed, Space.World);
		transform.position = new Vector3 (transform.position.x, transform.position.y, miner.position.z);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Zombie") {
			coll.GetComponent<Zombie>().HP -= Damage;
		}
	}
}
