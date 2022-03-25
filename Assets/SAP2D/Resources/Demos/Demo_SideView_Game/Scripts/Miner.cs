using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Miner : MonoBehaviour {

	public float HP;
	public float WalkingSpeed;
	public float ClimbingSpeed;
	public float ThrowForce;
	public Animator Anim;
	public Text HPText;
	public GameObject pickaxePrefab;

	[HideInInspector]
	public bool OnLadder;
	[HideInInspector]
	public Vector3 startClimbPos;

	private Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){

		HPText.text = "" + HP;
		if (HP <= 0) {
			gameObject.SetActive(false);
		}

		Vector3 dir = Vector3.zero;
		Anim.SetBool ("Move", false);

		if (Input.GetKey (KeyCode.A)) {
			Anim.SetBool ("Move", true);
			Anim.SetBool ("Climb", false);
			dir = Vector3.left;
			rb.isKinematic = false;
		}
		if (Input.GetKey (KeyCode.D)) {
			Anim.SetBool ("Move", true);
			Anim.SetBool ("Climb", false);
			dir = Vector3.right;
			rb.isKinematic = false;
		}
		if (OnLadder) {
			Anim.SetBool ("Climb", false);
			if (Input.GetKey (KeyCode.W)) {
				Anim.SetBool ("Climb", true);
				dir = Vector3.up;
				rb.isKinematic = true;
				transform.position = new Vector3 (startClimbPos.x, transform.position.y, transform.position.z);
			}
			if (Input.GetKey (KeyCode.S)) {
				rb.isKinematic = false;
				Anim.SetBool ("Climb", true);
				dir = Vector3.down;
				transform.position = new Vector3 (startClimbPos.x, transform.position.y, transform.position.z);
			}
		} else {
			if(Input.GetMouseButtonDown(0)){
				StartCoroutine(Throwing());
			}
		}
		MinerMove (dir);
		Anim.SetFloat ("WalkDir", dir.x);
	}

	IEnumerator Throwing(){
		Anim.SetBool ("Throw", true);
		yield return new WaitForSeconds (0.1f);
		GameObject pickaxe = Instantiate (pickaxePrefab, transform.position , Quaternion.identity) as GameObject;
		pickaxe.GetComponent<pickaxe> ().mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pickaxe.GetComponent<pickaxe> ().speed = ThrowForce;
		Anim.SetBool ("Throw", false);
		Destroy (pickaxe, 5f);
	}

	void MinerMove(Vector3 dir){
		rb.velocity = new Vector2 (dir.x * WalkingSpeed * Time.deltaTime, dir.y * ClimbingSpeed * Time.deltaTime);
	}
}
